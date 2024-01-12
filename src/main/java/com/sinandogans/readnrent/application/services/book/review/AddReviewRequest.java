package com.sinandogans.readnrent.application.services.book.review;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@AllArgsConstructor
@Setter
@NoArgsConstructor
public class AddReviewRequest {
    private Long bookId;
    private String text;
}
