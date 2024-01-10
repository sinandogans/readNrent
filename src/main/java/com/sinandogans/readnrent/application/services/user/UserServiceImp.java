package com.sinandogans.readnrent.application.services.user;

import com.sinandogans.readnrent.application.repositories.ReadingGoalRepository;
import com.sinandogans.readnrent.application.repositories.UserRepository;
import com.sinandogans.readnrent.application.security.hashing.HashService;
import com.sinandogans.readnrent.application.security.jwt.JwtService;
import com.sinandogans.readnrent.application.services.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.services.shared.response.IResponse;
import com.sinandogans.readnrent.application.services.shared.response.SuccessDataResponse;
import com.sinandogans.readnrent.application.services.shared.response.SuccessResponse;
import com.sinandogans.readnrent.application.services.user.login.UserLoginRequest;
import com.sinandogans.readnrent.application.services.user.login.UserLoginResponse;
import com.sinandogans.readnrent.application.services.user.register.UserRegisterRequest;
import com.sinandogans.readnrent.domain.user.User;
import jakarta.servlet.http.HttpServletRequest;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.Arrays;

@Service
public class UserServiceImp implements UserService {
    private final UserRepository userRepository;
    private final ReadingGoalRepository readingGoalRepository;
    private final ModelMapper modelMapper;
    private final HashService hashService;
    private final JwtService jwtService;
    private HttpServletRequest request;

    public UserServiceImp(UserRepository userRepository, ReadingGoalRepository readingGoalRepository, ModelMapper modelMapper, HashService hashService, JwtService jwtService, HttpServletRequest request) {
        this.userRepository = userRepository;
        this.readingGoalRepository = readingGoalRepository;
        this.modelMapper = modelMapper;
        this.hashService = hashService;
        this.jwtService = jwtService;
        this.request = request;
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
        return new SuccessResponse("created");
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
