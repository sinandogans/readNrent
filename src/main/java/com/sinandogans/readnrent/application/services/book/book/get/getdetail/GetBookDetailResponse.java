package com.sinandogans.readnrent.application.services.book.book.get.getdetail;

import com.sinandogans.readnrent.domain.book.Book;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;
import java.util.List;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class GetBookDetailResponse {
    private String name;
    private String imagePath;
    private String description;
    private int pages;
    private String publisher;
    private LocalDate publicationDate;
    private GetBookDetailStatisticsDTO statistics;
    private List<GetBookDetailAuthorDTO> authors;
    private List<GetBookDetailCategoryDTO> categories;
    private List<GetBookDetailReviewDTO> reviews;

    public static GetBookDetailResponse create(Book book) {
        var response = new GetBookDetailResponse();
        response.setName(book.getName());
        response.setImagePath(book.getImagePath());
        response.setDescription(book.getDescription());
        response.setPages(book.getPages());
        response.setPublisher(book.getPublisher());
        response.setPublicationDate(book.getPublicationDate());
        response.setStatistics(new GetBookDetailStatisticsDTO(book.getReviews().size(), book.getLikeCount(), 0, book.getReadCount(), book.getReadingCount(), book.getToBeReadCount()));

        response.setAuthors(book.getAuthors().stream().map(author -> new GetBookDetailAuthorDTO(author.getId(), author.getFullName())).toList());
        response.setCategories(book.getCategories().stream().map(category -> new GetBookDetailCategoryDTO(category.getId(), category.getName())).toList());
        response.setReviews(book.getReviews().stream().map(review -> new GetBookDetailReviewDTO(review.getId(), review.getText(), review.getUser().getUsername(), review.getUsersLiked().stream().map(user -> user.getUsername()).toList(), review.getComments().stream().map(comment -> new GetBookDetailCommentDTO(comment.getId(), comment.getText(), comment.getUser().getUsername())).toList())).toList());
        return response;
    }
}
