package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.services.user.login.UserLoginResponse;
import com.sinandogans.readnrent.application.services.user.role.addrole.AddRoleRequest;
import com.sinandogans.readnrent.application.services.user.role.assignrole.AssignRoleToUserRequest;
import com.sinandogans.readnrent.application.services.user.role.assignrole.AssignRoleToUserResponse;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
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
    public IDataResponse<UserLoginResponse> login(@RequestBody UserLoginRequest loginRequest) {
        return userService.login(loginRequest);
    }

    @PostMapping(value = "add-role")
    public IResponse addRole(@RequestBody AddRoleRequest addRoleRequest) {
        return userService.addRole(addRoleRequest);
    }

    @PostMapping(value = "assign-role")
    public IDataResponse<AssignRoleToUserResponse> login(@RequestBody AssignRoleToUserRequest assignRoleToUserRequest) {
        return userService.assignRoleToUser(assignRoleToUserRequest);
    }
}
