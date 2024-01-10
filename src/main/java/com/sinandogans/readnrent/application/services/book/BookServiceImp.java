package com.sinandogans.readnrent.application.services.book;

import com.sinandogans.readnrent.application.repositories.BookRepository;
import com.sinandogans.readnrent.domain.book.Book;
import org.springframework.stereotype.Service;

@Service
public class BookServiceImp implements BookService{
    private final BookRepository bookRepository;

    public BookServiceImp(BookRepository bookRepository) {
        this.bookRepository = bookRepository;
    }

    @Override
    public Book getById(Long id) {
        var optionalBook = bookRepository.findById(id);
        if (optionalBook.isEmpty())
            throw new RuntimeException("book id yok");
        return optionalBook.get();
    }
}
