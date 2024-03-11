package com.sinandogans.readnrent.application.services.user.user.get;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
public class FollowingUserDTO {
    private String username;
    private String fullName;
    private String profilePhotoPath;
    private int readBookCount;

    public static FollowingUserDTO create(String username, String fullName, String profilePhotoPath, int readBookCount) {
        return new FollowingUserDTO(username, fullName, profilePhotoPath, readBookCount);
    }
}
