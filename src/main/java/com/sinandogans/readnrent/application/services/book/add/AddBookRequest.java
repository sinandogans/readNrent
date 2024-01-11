package com.sinandogans.readnrent.application.services.book.add;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;
import java.util.List;

@Getter
@AllArgsConstructor
@Setter
public class AddBookRequest {
    private String name;
    private String description;
    private int pages;
    private String publisher;
    private LocalDate publicationDate;
    private List<Long> authorIds;
    private Long categoryId;
}
