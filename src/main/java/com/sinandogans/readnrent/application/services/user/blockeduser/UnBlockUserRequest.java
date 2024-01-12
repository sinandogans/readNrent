package com.sinandogans.readnrent.application.services.user.blockeduser;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class UnBlockUserRequest {
    private String username;
}
