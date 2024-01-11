package com.sinandogans.readnrent.application.services.book;

import com.sinandogans.readnrent.application.services.book.add.AddBookRequest;
import com.sinandogans.readnrent.application.services.book.update.UpdateBookRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.book.Category;

public interface BookService {
    Book getById(Long id);

    Category getCategoryById(Long id);

    void updateBook(Book book);

    IResponse addBook(AddBookRequest addBookRequest);

    IResponse updateBook(UpdateBookRequest updateBookRequest);

    IResponse deleteBook(Long id);
}
