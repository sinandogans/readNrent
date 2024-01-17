package com.sinandogans.readnrent.application.services.library.userbook.responses;

import lombok.AllArgsConstructor;
import lombok.Getter;

import java.util.List;

@Getter
@AllArgsConstructor
public class GetUserBooksBookDTO {
    private String name;
    private GetUserBooksCategoryDTO category;
    private List<GetUserBooksAuthorDTO> authors;
}
