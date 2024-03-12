package com.sinandogans.readnrent.application.services.user.user.login;

import lombok.AllArgsConstructor;
import lombok.Getter;

@AllArgsConstructor
@Getter
public class UserLoginResponse {
    private String jwtToken;
    private String username;
}
