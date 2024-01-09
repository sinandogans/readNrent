package com.sinandogans.readnrent.domain.book;

import com.sinandogans.readnrent.domain.library.UserBook;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;
import java.util.List;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class Book {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String name;
    private String description;
    private int pages;
    private String publisher;
    private LocalDate publicationDate;
    private double rating;
    private int readCount;
    private int likes;
    @ManyToMany
    private List<Author> authors;
    @ManyToOne
    private Category category;
    @OneToMany(mappedBy = "book")
    private List<UserBook> userBooks;
}
