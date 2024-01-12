package com.sinandogans.readnrent.application.services.book.category;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;
import java.util.List;

@Getter
@AllArgsConstructor
@Setter
@NoArgsConstructor
public class AddCategoryRequest {
    private String name;
}
