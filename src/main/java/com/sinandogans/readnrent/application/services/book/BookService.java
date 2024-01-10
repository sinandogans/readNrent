package com.sinandogans.readnrent.application.services.book;

import com.sinandogans.readnrent.domain.book.Book;

public interface BookService {
    Book getById(Long id);
}
