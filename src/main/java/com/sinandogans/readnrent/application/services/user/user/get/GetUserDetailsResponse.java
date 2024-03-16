package com.sinandogans.readnrent.application.services.user.user.get;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.util.List;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class GetUserDetailsResponse {
    private Long id;
    private String username;
    private String fullName;
    private String profilePhotoPath;
    private String coverPhotoPath;
    private List<FollowDTO> followingUsers;
    private List<FollowDTO> followers;
}
