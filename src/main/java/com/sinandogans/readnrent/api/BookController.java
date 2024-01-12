package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.services.book.BookService;
import com.sinandogans.readnrent.application.services.book.book.add.AddBookRequest;
import com.sinandogans.readnrent.application.services.book.category.AddCategoryRequest;
import com.sinandogans.readnrent.application.services.book.category.UpdateCategoryRequest;
import com.sinandogans.readnrent.application.services.book.book.update.UpdateBookRequest;
import com.sinandogans.readnrent.application.services.book.review.AddReviewRequest;
import com.sinandogans.readnrent.application.services.book.review.UpdateReviewRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import org.springframework.web.bind.annotation.*;

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
}
