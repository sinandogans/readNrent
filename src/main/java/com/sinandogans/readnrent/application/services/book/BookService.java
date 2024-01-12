package com.sinandogans.readnrent.application.services.book;

import com.sinandogans.readnrent.application.services.book.book.add.AddBookRequest;
import com.sinandogans.readnrent.application.services.book.category.AddCategoryRequest;
import com.sinandogans.readnrent.application.services.book.category.UpdateCategoryRequest;
import com.sinandogans.readnrent.application.services.book.book.update.UpdateBookRequest;
import com.sinandogans.readnrent.application.services.book.comment.AddCommentRequest;
import com.sinandogans.readnrent.application.services.book.comment.UpdateCommentRequest;
import com.sinandogans.readnrent.application.services.book.review.AddReviewRequest;
import com.sinandogans.readnrent.application.services.book.review.UpdateReviewRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.book.Category;
import com.sinandogans.readnrent.domain.book.Comment;
import com.sinandogans.readnrent.domain.book.Review;

public interface BookService {
    Book getById(Long id);

    Category getCategoryById(Long id);

    Category getCategoryByName(String name);

    Review getReviewById(Long id);

    Comment getCommentById(Long id);

    void updateBook(Book book);

    IResponse addBook(AddBookRequest addBookRequest);

    IResponse updateBook(UpdateBookRequest updateBookRequest);

    IResponse deleteBook(Long id);

    IResponse addCategory(AddCategoryRequest addCategoryRequest);

    IResponse updateCategory(UpdateCategoryRequest updateCategoryRequest);

    IResponse deleteCategory(Long id);

    IResponse addReview(AddReviewRequest addReviewRequest);

    IResponse updateReview(UpdateReviewRequest updateReviewRequest);

    IResponse deleteReview(Long id);

    IResponse likeReview(Long reviewId);

    IResponse addComment(AddCommentRequest addCommentRequest);

    IResponse updateComment(UpdateCommentRequest updateCommentRequest);

    IResponse deleteComment(Long id);

    IResponse likeComment(Long commentId);
}
