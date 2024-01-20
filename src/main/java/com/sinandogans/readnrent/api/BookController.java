package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.services.book.BookService;
import com.sinandogans.readnrent.application.services.book.book.add.AddBookRequest;
import com.sinandogans.readnrent.application.services.book.book.get.getdetail.GetBookDetailResponse;
import com.sinandogans.readnrent.application.services.book.category.AddCategoryRequest;
import com.sinandogans.readnrent.application.services.book.category.GetCategoriesResponseModel;
import com.sinandogans.readnrent.application.services.book.category.UpdateCategoryRequest;
import com.sinandogans.readnrent.application.services.book.book.update.UpdateBookRequest;
import com.sinandogans.readnrent.application.services.book.comment.AddCommentRequest;
import com.sinandogans.readnrent.application.services.book.comment.UpdateCommentRequest;
import com.sinandogans.readnrent.application.services.book.review.AddReviewRequest;
import com.sinandogans.readnrent.application.services.book.review.UpdateReviewRequest;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("books")
public class BookController {
    private final BookService bookService;

    public BookController(BookService bookService) {
        this.bookService = bookService;
    }

    @PostMapping(value = "add")
    public IResponse addBook(@RequestBody AddBookRequest addBookRequest) {
        return bookService.addBook(addBookRequest);
    }

    @PutMapping(value = "update")
    public IResponse updateBook(@RequestBody UpdateBookRequest updateBookRequest) {
        return bookService.updateBook(updateBookRequest);
    }

    @DeleteMapping(value = "delete")
    public IResponse deleteBook(@RequestParam Long id) {
        return bookService.deleteBook(id);
    }

    @GetMapping(value = "get-detail")
    public IDataResponse<GetBookDetailResponse> updateBook(@RequestParam Long id) {
        return bookService.getBookDetail(id);
    }

    @PostMapping(value = "categories/add")
    public IResponse addCategory(@RequestBody AddCategoryRequest addCategoryRequest) {
        return bookService.addCategory(addCategoryRequest);
    }

    @PutMapping(value = "categories/update")
    public IResponse updateCategory(@RequestBody UpdateCategoryRequest updateCategoryRequest) {
        return bookService.updateCategory(updateCategoryRequest);
    }

    @DeleteMapping(value = "categories/delete")
    public IResponse deleteCategory(@RequestParam Long id) {
        return bookService.deleteCategory(id);
    }

    @GetMapping(value = "categories/get-all")
    public IDataResponse<List<GetCategoriesResponseModel>> getAllCategories() {
        return bookService.getAllCategories();
    }

    @PostMapping(value = "reviews/add")
    public IResponse addReview(@RequestBody AddReviewRequest addReviewRequest) {
        return bookService.addReview(addReviewRequest);
    }

    @PutMapping(value = "reviews/update")
    public IResponse updateReview(@RequestBody UpdateReviewRequest updateReviewRequest) {
        return bookService.updateReview(updateReviewRequest);
    }

    @DeleteMapping(value = "reviews/delete")
    public IResponse deleteReview(@RequestParam Long id) {
        return bookService.deleteReview(id);
    }

    @PostMapping(value = "reviews/like")
    public IResponse likeReview(@RequestParam Long reviewId) {
        return bookService.likeReview(reviewId);
    }

    @PostMapping(value = "reviews/comments/add")
    public IResponse addComment(@RequestBody AddCommentRequest addCommentRequest) {
        return bookService.addComment(addCommentRequest);
    }

    @PutMapping(value = "reviews/comments/update")
    public IResponse updateComment(@RequestBody UpdateCommentRequest updateCommentRequest) {
        return bookService.updateComment(updateCommentRequest);
    }

    @DeleteMapping(value = "reviews/comments/delete")
    public IResponse deleteComment(@RequestParam Long id) {
        return bookService.deleteComment(id);
    }

    @PostMapping(value = "reviews/comments/like")
    public IResponse likeComment(@RequestParam Long commentId) {
        return bookService.likeComment(commentId);
    }
}
