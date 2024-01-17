package com.sinandogans.readnrent.application.services.user;

import com.sinandogans.readnrent.application.aspects.annotations.RolesAllowed;
import com.sinandogans.readnrent.application.repositories.BlockedUserRepository;
import com.sinandogans.readnrent.application.repositories.FollowedUserRepository;
import com.sinandogans.readnrent.application.repositories.UserRepository;
import com.sinandogans.readnrent.application.repositories.UserRoleRepository;
import com.sinandogans.readnrent.application.security.hashing.HashService;
import com.sinandogans.readnrent.application.security.jwt.JwtService;
import com.sinandogans.readnrent.application.services.user.blockeduser.BlockUserRequest;
import com.sinandogans.readnrent.application.services.user.blockeduser.UnBlockUserRequest;
import com.sinandogans.readnrent.application.services.user.followeduser.ChangeNotificationPreferenceRequest;
import com.sinandogans.readnrent.application.services.user.followeduser.FollowUserRequest;
import com.sinandogans.readnrent.application.services.user.followeduser.UnFollowUserRequest;
import com.sinandogans.readnrent.application.services.user.role.addrole.AddRoleRequest;
import com.sinandogans.readnrent.application.services.user.role.assignrole.AssignRoleToUserRequest;
import com.sinandogans.readnrent.application.services.user.role.assignrole.AssignRoleToUserResponse;
import com.sinandogans.readnrent.application.services.user.role.deassignrole.DeAssignRoleToUserRequest;
import com.sinandogans.readnrent.application.services.user.role.deassignrole.DeAssignRoleToUserResponse;
import com.sinandogans.readnrent.application.services.user.role.delete.DeleteRoleRequest;
import com.sinandogans.readnrent.application.services.user.role.get.GetRolesResponseModel;
import com.sinandogans.readnrent.application.services.user.user.checkadmin.CheckIfUserAdminResponse;
import com.sinandogans.readnrent.application.shared.response.*;
import com.sinandogans.readnrent.application.services.user.user.login.UserLoginRequest;
import com.sinandogans.readnrent.application.services.user.user.login.UserLoginResponse;
import com.sinandogans.readnrent.application.services.user.user.register.UserRegisterRequest;
import com.sinandogans.readnrent.domain.user.BlockedUser;
import com.sinandogans.readnrent.domain.user.FollowedUser;
import com.sinandogans.readnrent.domain.user.User;
import com.sinandogans.readnrent.domain.user.UserRole;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.List;
import java.util.Objects;

@Service
public class UserServiceImp implements UserService {
    private final UserRepository userRepository;
    private final UserRoleRepository roleRepository;
    private final FollowedUserRepository followedUserRepository;
    private final BlockedUserRepository blockedUserRepository;
    private final ModelMapper modelMapper;
    private final HashService hashService;
    private final JwtService jwtService;

    public UserServiceImp(UserRepository userRepository, UserRoleRepository roleRepository, FollowedUserRepository followedUserRepository, BlockedUserRepository blockedUserRepository, ModelMapper modelMapper, HashService hashService, JwtService jwtService) {
        this.userRepository = userRepository;
        this.roleRepository = roleRepository;
        this.followedUserRepository = followedUserRepository;
        this.blockedUserRepository = blockedUserRepository;
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
        checkIfPasswordAndPasswordConfirmationEquals(registerRequest);
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
        var user = getByEmailOrUsername(loginRequest.getEmailOrUsername());
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

    @Override
    @RolesAllowed(values = {"admin"})
    public IDataResponse<DeAssignRoleToUserResponse> deAssignRoleToUser(DeAssignRoleToUserRequest assignRoleToUserRequest) {
        var role = getRoleById(assignRoleToUserRequest.getRoleId());
        var user = getByUsername(assignRoleToUserRequest.getUsername());

        user.deleteRole(role);
        userRepository.save(user);
        return new SuccessDataResponse<>("role kullanicidan alindi", new DeAssignRoleToUserResponse(role.getRole(), user.getUsername()));
    }

    @Override
    @RolesAllowed(values = {"admin"})
    public IResponse addRole(AddRoleRequest addRoleRequest) {
        checkIfRoleAlreadyExist(addRoleRequest.getRole());
        roleRepository.save(new UserRole(null, addRoleRequest.getRole(), null));
        return new SuccessResponse("role eklendi");
    }

    @Override
    @RolesAllowed(values = {"admin"})
    public IResponse deleteRole(DeleteRoleRequest deleteRoleRequest) {
        roleRepository.delete(getRoleById(deleteRoleRequest.getId()));
        return new SuccessResponse("role silindi");
    }

    @Override
    public IResponse followUser(FollowUserRequest followUserRequest) {
        var userToFollow = getByUsername(followUserRequest.getUsername());
        var user = getUserFromJwtToken();

        checkIfUserBlocked(user, userToFollow);

        FollowedUser followedUser = new FollowedUser(null, user, userToFollow, true, LocalDateTime.now());
        user.addFollowedUser(followedUser);
        followedUserRepository.save(followedUser);
        return new SuccessResponse("kullanıcı takip edildi");
    }

    @Override
    public IResponse unFollowUser(UnFollowUserRequest unFollowUserRequest) {
        var userToUnFollow = getByUsername(unFollowUserRequest.getUsername());
        var user = getUserFromJwtToken();
        var followedUserIdToDelete = user.removeFollowedUser(userToUnFollow);
        followedUserRepository.deleteById(followedUserIdToDelete);
        return new SuccessResponse("kullanıcı takipten cikarildi");
    }

    @Override
    public IResponse changeNotificationPreference(ChangeNotificationPreferenceRequest changeNotificationPreferenceRequest) {
        var user = getUserFromJwtToken();
        FollowedUser followedUser = user.getFollowedUser(changeNotificationPreferenceRequest.getUsername());
        followedUser.setNotificationsEnabled(!followedUser.isNotificationsEnabled());
        followedUserRepository.save(followedUser);
        return new SuccessResponse("notification preference changed.");
    }

    @Override
    public IResponse blockUser(BlockUserRequest blockUserRequest) {
        var userTBlock = getByUsername(blockUserRequest.getUsername());
        var user = getUserFromJwtToken();
        BlockedUser blockedUser = new BlockedUser(null, user, userTBlock, LocalDateTime.now());
        user.addBlockedUser(blockedUser);
        blockedUserRepository.save(blockedUser);
        if (user.isUserFollowing(userTBlock)) {
            var id = user.removeFollowedUser(userTBlock);
            followedUserRepository.deleteById(id);
        }
        return new SuccessResponse("kullanıcı blocklandı");
    }

    @Override
    public IResponse unBlockUser(UnBlockUserRequest unBlockUserRequest) {
        var userToUnBlock = getByUsername(unBlockUserRequest.getUsername());
        var user = getUserFromJwtToken();
        var blockedUserIdToDelete = user.removeBlockedUser(userToUnBlock);
        blockedUserRepository.deleteById(blockedUserIdToDelete);
        return new SuccessResponse("kullanıcı block listesinden cıkarildi");
    }

    @Override
    public IDataResponse<CheckIfUserAdminResponse> checkIfUserAdmin() {
        var user = getUserFromJwtToken();
        var roles = jwtService.getUserRoles();
        var filteredRoles = roles.stream().filter(role -> Objects.equals(role, "admin")).toList();
        if (filteredRoles.isEmpty())
            return new ErrorDataResponse<>("user admin deil", new CheckIfUserAdminResponse(false));
        return new SuccessDataResponse<>("user is admin", new CheckIfUserAdminResponse(true));
    }

    @Override
    public IDataResponse<List<GetRolesResponseModel>> getRoles() {
        var userRoles = getUserRoles();
        var getRolesResponse = userRoles.stream().map(role -> new GetRolesResponseModel(role.getId(), role.getRole())).toList();
        return new SuccessDataResponse<>("döndü", getRolesResponse);
    }

    public List<UserRole> getUserRoles() {
        var userRoles = roleRepository.findAll();
        if (userRoles.isEmpty())
            throw new RuntimeException("hiç rol yok");
        return userRoles;
    }

    public User getUserFromJwtToken() {
        var email = jwtService.getUserEmailFromJwtToken();
        return getByEmail(email);
    }

    private UserRole getRoleById(Long id) {
        var optionalRole = roleRepository.findById(id);
        if (optionalRole.isEmpty())
            throw new RuntimeException("bu id ile rol yok");
        return optionalRole.get();
    }

    private void checkIfRoleAlreadyExist(String role) {
        var optionalRole = roleRepository.findByRole(role);
        if (optionalRole.isPresent())
            throw new RuntimeException("role zaten var");
    }

    private void checkIfUserBlocked(User user, User blockedUser) {
        if (user.isUserBlocked(blockedUser))
            throw new RuntimeException("bloklu kullanıcı takip edilemez");
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

    private void checkIfPasswordAndPasswordConfirmationEquals(UserRegisterRequest registerRequest) {
        if (!Objects.equals(registerRequest.getPassword(), registerRequest.getPasswordConfirmation()))
            throw new RuntimeException("passwordlar aynı olmalı");

    }

    public User getByEmailOrUsername(String emailOrUsername) {
        var optionalUser = userRepository.findByEmail(emailOrUsername);
        if (optionalUser.isPresent())
            return optionalUser.get();
        optionalUser = userRepository.findByUsername(emailOrUsername);
        if (optionalUser.isPresent())
            return optionalUser.get();
        throw new RuntimeException("bu email veya username ile kullanıcı yok");
    }
}
