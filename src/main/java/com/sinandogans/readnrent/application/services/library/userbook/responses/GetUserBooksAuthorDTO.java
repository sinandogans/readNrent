package com.sinandogans.readnrent.application.services.library.userbook.responses;

import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class GetUserBooksAuthorDTO {
    private Long id;
    private String name;
    private String imagePath;
}
