package com.sinandogans.readnrent.application.services.book.book.get.getdetail;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.util.List;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class GetBookDetailResponse {
    private String name;
    private String imagePath;
    private List<GetBookDetailAuthorDTO> authors;
}
