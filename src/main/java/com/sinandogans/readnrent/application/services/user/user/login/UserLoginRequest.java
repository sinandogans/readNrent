package com.sinandogans.readnrent.application.services.user.user.login;

import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class UserLoginRequest {
    private String email;
    private String password;
}
