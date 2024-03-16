package com.sinandogans.readnrent.application.services.book.book.get.getdetail;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.util.List;

@Setter
@Getter
@NoArgsConstructor
@AllArgsConstructor
public class GetBookDetailReviewDTO {
    private Long id;
    private String text;
    private String username;
    private List<String> usersLiked;
    private List<GetBookDetailCommentDTO> comments;
}
