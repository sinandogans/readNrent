package com.sinandogans.readnrent.application.services.book.review;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@AllArgsConstructor
@Setter
@NoArgsConstructor
public class UpdateReviewRequest {
    private Long reviewId;
    private String text;
}
