package com.sinandogans.readnrent.application.services.library.userbook.responses;

import lombok.AllArgsConstructor;
import lombok.Getter;

import java.util.List;

@Getter
@AllArgsConstructor
public class GetUserBooksBookDTO {
    private Long id;
    private String name;
    private String imagePath;
    private List<GetUserBooksCategoryDTO> categories;
    private List<GetUserBooksAuthorDTO> authors;
}
