package com.sinandogans.readnrent.application.services.user.role.deassignrole;

import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class DeAssignRoleToUserResponse {
    private String role;
    private String username;
}
