package com.sinandogans.readnrent.application.services.book;

import com.sinandogans.readnrent.application.services.book.add.AddBookRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.book.Category;
import com.sinandogans.readnrent.domain.book.Review;

public interface BookService {
    Book getById(Long id);
    Category getCategoryById(Long id);

    void addReview(Review review);

    void updateBook(Book book);

    IResponse addBook(AddBookRequest addBookRequest);
}
