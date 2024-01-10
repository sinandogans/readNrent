package com.sinandogans.readnrent.application.services.library.userbook.requests;

import com.sinandogans.readnrent.domain.library.ReadType;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Getter
@NoArgsConstructor
@AllArgsConstructor
public class UpdateUserBookRequest {
    private Long bookId;
    private ReadType readType;
    private double rating;
    private boolean liked;
    private LocalDate startDate;
    private LocalDate finishDate;
    private String note;
    private String review;
}
