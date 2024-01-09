package com.sinandogans.readnrent.domain.library;

import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.user.User;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class UserBook {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @ManyToOne
    private User user;
    @ManyToOne
    private Book book;

    private ReadType readType;
    private double rating;
    private boolean liked;
    private LocalDate startDate;
    private LocalDate finishDate;
    private String note;
    private String review;
}
