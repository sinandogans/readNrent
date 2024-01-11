package com.sinandogans.readnrent.application.services.book.get;

import com.sinandogans.readnrent.domain.book.Author;
import com.sinandogans.readnrent.domain.book.Category;
import com.sinandogans.readnrent.domain.library.Review;
import com.sinandogans.readnrent.domain.library.UserBook;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
public class GetAllBooksResponse {
    private String name;
    private String description;
    private int pages;
    private String publisher;
    private LocalDate publicationDate;
    private Category category;
    private List<Author> authors = new ArrayList<>();
    private List<UserBook> userBooks = new ArrayList<>();
    private List<Review> reviews = new ArrayList<>();
}
