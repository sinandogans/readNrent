package com.sinandogans.readnrent.application.services.user.followeduser;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class ChangeNotificationPreferenceRequest {
    private String username;
}
