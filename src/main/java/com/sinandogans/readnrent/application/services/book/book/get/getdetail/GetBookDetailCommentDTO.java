package com.sinandogans.readnrent.application.services.book.book.get.getdetail;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Setter
@Getter
@NoArgsConstructor
@AllArgsConstructor
public class GetBookDetailCommentDTO {
    private Long id;
    private String text;
    private String username;
}
