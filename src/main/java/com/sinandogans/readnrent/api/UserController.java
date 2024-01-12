package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.services.user.followeduser.ChangeNotificationPreferenceRequest;
import com.sinandogans.readnrent.application.services.user.followeduser.FollowUserRequest;
import com.sinandogans.readnrent.application.services.user.followeduser.UnFollowUserRequest;
import com.sinandogans.readnrent.application.services.user.user.login.UserLoginResponse;
import com.sinandogans.readnrent.application.services.user.role.addrole.AddRoleRequest;
import com.sinandogans.readnrent.application.services.user.role.assignrole.AssignRoleToUserRequest;
import com.sinandogans.readnrent.application.services.user.role.assignrole.AssignRoleToUserResponse;
import com.sinandogans.readnrent.application.services.user.role.deassignrole.DeAssignRoleToUserRequest;
import com.sinandogans.readnrent.application.services.user.role.deassignrole.DeAssignRoleToUserResponse;
import com.sinandogans.readnrent.application.services.user.role.delete.DeleteRoleRequest;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.application.services.user.UserService;
import com.sinandogans.readnrent.application.services.user.user.login.UserLoginRequest;
import com.sinandogans.readnrent.application.services.user.user.register.UserRegisterRequest;
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

    @DeleteMapping(value = "delete-role")
    public IResponse addRole(@RequestBody DeleteRoleRequest deleteRoleRequest) {
        return userService.deleteRole(deleteRoleRequest);
    }

    @PostMapping(value = "assign-role")
    public IDataResponse<AssignRoleToUserResponse> login(@RequestBody AssignRoleToUserRequest assignRoleToUserRequest) {
        return userService.assignRoleToUser(assignRoleToUserRequest);
    }

    @PostMapping(value = "deassign-role")
    public IDataResponse<DeAssignRoleToUserResponse> login(@RequestBody DeAssignRoleToUserRequest deAssignRoleToUserRequest) {
        return userService.deAssignRoleToUser(deAssignRoleToUserRequest);
    }

    @PostMapping(value = "follow-user")
    public IResponse login(@RequestBody FollowUserRequest followUserRequest) {
        return userService.followUser(followUserRequest);
    }

    @PostMapping(value = "change-notification-pref")
    public IResponse login(@RequestBody ChangeNotificationPreferenceRequest changeNotificationPreferenceRequest) {
        return userService.changeNotificationPreference(changeNotificationPreferenceRequest);
    }

    @PostMapping(value = "unfollow-user")
    public IResponse login(@RequestBody UnFollowUserRequest unFollowUserRequest) {
        return userService.unFollowUser(unFollowUserRequest);
    }
}
