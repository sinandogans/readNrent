package com.sinandogans.readnrent.application.services.user.role.deassignrole;

import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class DeAssignRoleToUserRequest {
    private Long roleId;
    private String username;
}
