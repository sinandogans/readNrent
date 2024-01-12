package com.sinandogans.readnrent.application.services.user;

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
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.application.services.user.user.login.UserLoginRequest;
import com.sinandogans.readnrent.application.services.user.user.login.UserLoginResponse;
import com.sinandogans.readnrent.application.services.user.user.register.UserRegisterRequest;
import com.sinandogans.readnrent.domain.user.User;

public interface UserService {
    User getByEmail(String email);

    User getById(Long id);

    User getByUsername(String username);

    User getUserFromJwtToken();

    IResponse register(UserRegisterRequest registerRequest);

    IDataResponse<UserLoginResponse> login(UserLoginRequest userLoginRequest);

    IDataResponse<AssignRoleToUserResponse> assignRoleToUser(AssignRoleToUserRequest assignRoleToUserRequest);

    IDataResponse<DeAssignRoleToUserResponse> deAssignRoleToUser(DeAssignRoleToUserRequest assignRoleToUserRequest);

    IResponse addRole(AddRoleRequest addRoleRequest);

    IResponse deleteRole(DeleteRoleRequest deleteRoleRequest);

    IResponse followUser(FollowUserRequest followUserRequest);

    IResponse unFollowUser(UnFollowUserRequest unFollowUserRequest);

    IResponse changeNotificationPreference(ChangeNotificationPreferenceRequest changeNotificationPreferenceRequest);

    IResponse blockUser(BlockUserRequest blockUserRequest);

    IResponse unBlockUser(UnBlockUserRequest unBlockUserRequest);
}
