package com.sinandogans.readnrent.application.services.user.role.assignrole;

import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class AssignRoleToUserRequest {
    private Long roleId;
    private String username;
}
