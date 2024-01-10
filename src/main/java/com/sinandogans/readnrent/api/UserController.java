package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.services.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.services.shared.response.IResponse;
import com.sinandogans.readnrent.application.services.user.UserService;
import com.sinandogans.readnrent.application.services.user.login.UserLoginRequest;
import com.sinandogans.readnrent.application.services.user.register.UserRegisterRequest;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("users")
public class UserController {
    private final UserService userService;

    public UserController(UserService userService) {
        this.userService = userService;
    }

    @PostMapping(value = "register")
    public IResponse register(@RequestBody UserRegisterRequest registerRequest) {
        return userService.register(registerRequest);
    }

    @PostMapping(value = "login")
    public IDataResponse login(@RequestBody UserLoginRequest loginRequest) {
        //userService.addReadingGoal(new AddReadingGoalRequest(10));
        return userService.login(loginRequest);
    }
}
