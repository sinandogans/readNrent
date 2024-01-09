package com.sinandogans.readnrent.application.services.user.register;

import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class UserRegisterRequest {
    private String email;
    private String username;
    private String firstName;
    private String lastName;
    private String password;
}
