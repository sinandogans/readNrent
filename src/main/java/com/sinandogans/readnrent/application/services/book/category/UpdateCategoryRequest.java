package com.sinandogans.readnrent.application.services.book.category;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@Getter
@AllArgsConstructor
@Setter
public class UpdateCategoryRequest {
    private Long id;
    private String name;
}
