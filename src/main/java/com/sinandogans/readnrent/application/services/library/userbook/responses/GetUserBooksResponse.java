package com.sinandogans.readnrent.application.services.library.userbook.responses;

import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.library.ReadType;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;

@Getter
@NoArgsConstructor
@AllArgsConstructor
@Setter
public class GetUserBooksResponse {
    private ReadType readType;
    private double rating;
    private boolean liked;
    private LocalDate startDate;
    private LocalDate finishDate;
    private String note;
    private GetUserBooksBookDTO book;
}
