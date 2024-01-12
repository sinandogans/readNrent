package com.sinandogans.readnrent.application.services.book.comment;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@AllArgsConstructor
@Setter
@NoArgsConstructor
public class AddCommentRequest {
    private Long reviewId;
    private String text;
}
