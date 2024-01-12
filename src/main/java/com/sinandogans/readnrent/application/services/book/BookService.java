package com.sinandogans.readnrent.application.services.book;

import com.sinandogans.readnrent.application.services.book.add.AddBookRequest;
import com.sinandogans.readnrent.application.services.book.category.AddCategoryRequest;
import com.sinandogans.readnrent.application.services.book.category.UpdateCategoryRequest;
import com.sinandogans.readnrent.application.services.book.update.UpdateBookRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.book.Category;

public interface BookService {
    Book getById(Long id);

    Category getCategoryById(Long id);

    Category getCategoryByName(String name);

    void updateBook(Book book);

    IResponse addBook(AddBookRequest addBookRequest);

    IResponse updateBook(UpdateBookRequest updateBookRequest);

    IResponse deleteBook(Long id);

    IResponse addCategory(AddCategoryRequest addCategoryRequest);

    IResponse updateCategory(UpdateCategoryRequest updateCategoryRequest);

    IResponse deleteCategory(Long id);
}
