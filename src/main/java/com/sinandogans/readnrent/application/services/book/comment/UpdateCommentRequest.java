package com.sinandogans.readnrent.application.services.book.comment;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@AllArgsConstructor
@Setter
@NoArgsConstructor
public class UpdateCommentRequest {
    private Long commentId;
    private String text;
}
