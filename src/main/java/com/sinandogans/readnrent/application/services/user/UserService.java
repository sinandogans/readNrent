package com.sinandogans.readnrent.application.services.user;

import com.sinandogans.readnrent.application.services.user.role.addrole.AddRoleRequest;
import com.sinandogans.readnrent.application.services.user.role.assignrole.AssignRoleToUserRequest;
import com.sinandogans.readnrent.application.services.user.role.assignrole.AssignRoleToUserResponse;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.application.services.user.login.UserLoginRequest;
import com.sinandogans.readnrent.application.services.user.login.UserLoginResponse;
import com.sinandogans.readnrent.application.services.user.register.UserRegisterRequest;
import com.sinandogans.readnrent.domain.user.User;

public interface UserService {
    User getByEmail(String email);

    User getById(Long id);

    User getByUsername(String username);

    IResponse register(UserRegisterRequest registerRequest);

    IDataResponse<UserLoginResponse> login(UserLoginRequest userLoginRequest);

    IDataResponse<AssignRoleToUserResponse> assignRoleToUser(AssignRoleToUserRequest assignRoleToUserRequest);

    IResponse addRole(AddRoleRequest addRoleRequest);
}
