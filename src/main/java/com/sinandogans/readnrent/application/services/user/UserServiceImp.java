package com.sinandogans.readnrent.application.services.user;

import com.sinandogans.readnrent.application.aspects.annotations.RolesAllowed;
import com.sinandogans.readnrent.application.repositories.UserRepository;
import com.sinandogans.readnrent.application.repositories.UserRoleRepository;
import com.sinandogans.readnrent.application.security.hashing.HashService;
import com.sinandogans.readnrent.application.security.jwt.JwtService;
import com.sinandogans.readnrent.application.services.user.role.addrole.AddRoleRequest;
import com.sinandogans.readnrent.application.services.user.role.assignrole.AssignRoleToUserRequest;
import com.sinandogans.readnrent.application.services.user.role.assignrole.AssignRoleToUserResponse;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.application.shared.response.SuccessDataResponse;
import com.sinandogans.readnrent.application.shared.response.SuccessResponse;
import com.sinandogans.readnrent.application.services.user.login.UserLoginRequest;
import com.sinandogans.readnrent.application.services.user.login.UserLoginResponse;
import com.sinandogans.readnrent.application.services.user.register.UserRegisterRequest;
import com.sinandogans.readnrent.domain.user.User;
import com.sinandogans.readnrent.domain.user.UserRole;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.Arrays;

@Service
public class UserServiceImp implements UserService {
    private final UserRepository userRepository;
    private final UserRoleRepository roleRepository;
    private final ModelMapper modelMapper;
    private final HashService hashService;
    private final JwtService jwtService;

    public UserServiceImp(UserRepository userRepository, UserRoleRepository roleRepository, ModelMapper modelMapper, HashService hashService, JwtService jwtService) {
        this.userRepository = userRepository;
        this.roleRepository = roleRepository;
        this.modelMapper = modelMapper;
        this.hashService = hashService;
        this.jwtService = jwtService;
    }

    @Override
    public User getByEmail(String email) {
        var optionalUser = userRepository.findByEmail(email);
        if (optionalUser.isEmpty())
            throw new RuntimeException("email yok");
        return optionalUser.get();
    }

    @Override
    public User getById(Long id) {
        var optionalUser = userRepository.findById(id);
        if (optionalUser.isEmpty())
            throw new RuntimeException("id yok");
        return optionalUser.get();
    }

    @Override
    public User getByUsername(String username) {
        var optionalUser = userRepository.findByUsername(username);
        if (optionalUser.isEmpty())
            throw new RuntimeException("username yok");
        return optionalUser.get();
    }

    @Override
    public IResponse register(UserRegisterRequest registerRequest) {
        checkIfEmailAlreadyExist(registerRequest.getEmail());
        checkIfUsernameAlreadyExist(registerRequest.getUsername());

        User userToRegister = modelMapper.map(registerRequest, User.class);
        userToRegister.setPasswordSalt(hashService.saltPassword(registerRequest.getPassword()));
        userToRegister.setPasswordHash(hashService.hashPassword(registerRequest.getPassword(), userToRegister.getPasswordSalt()));

        userRepository.save(userToRegister);
        return new SuccessResponse("user created");
    }

    @Override
    public IDataResponse<UserLoginResponse> login(UserLoginRequest loginRequest) {
        var user = getByEmail(loginRequest.getEmail());
        var hashedPassword = hashService.hashPassword(loginRequest.getPassword(), user.getPasswordSalt());
        if (!Arrays.equals(hashedPassword, user.getPasswordHash()))
            throw new RuntimeException("incorrect password");
        return new SuccessDataResponse<>(
                "giris yapıldı",
                new UserLoginResponse(jwtService.createToken(user))
        );
    }

    @Override
    @RolesAllowed(values = {"admin"})
    public IDataResponse<AssignRoleToUserResponse> assignRoleToUser(AssignRoleToUserRequest assignRoleToUserRequest) {
        var role = getRoleById(assignRoleToUserRequest.getRoleId());
        var user = getByUsername(assignRoleToUserRequest.getUsername());

        user.addRole(role);
        userRepository.save(user);
        return new SuccessDataResponse<>("role verildi", new AssignRoleToUserResponse(role.getRole(), user.getUsername()));
    }


    public UserRole getRoleById(Long id) {
        var optionalRole = roleRepository.findById(id);
        if (optionalRole.isEmpty())
            throw new RuntimeException("bu id ile rol yok");
        return optionalRole.get();
    }

    @Override
    @RolesAllowed(values = {"admin"})
    public IResponse addRole(AddRoleRequest addRoleRequest) {
        checkIfRoleAlreadyExist(addRoleRequest.getRole());
        roleRepository.save(new UserRole(null, addRoleRequest.getRole(), null));
        return new SuccessResponse("role eklendi");
    }

    private void checkIfRoleAlreadyExist(String role) {
        var optionalRole = roleRepository.findByRole(role);
        if (optionalRole.isPresent())
            throw new RuntimeException("role zaten var");
    }

    private void checkIfEmailAlreadyExist(String email) {
        var optionalUser = userRepository.findByEmail(email);
        if (optionalUser.isPresent())
            throw new RuntimeException("kayitli");
    }

    private void checkIfUsernameAlreadyExist(String username) {
        var optionalUser = userRepository.findByUsername(username);
        if (optionalUser.isPresent())
            throw new RuntimeException("kayitli");
    }

}
