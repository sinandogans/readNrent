package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.services.book.BookService;
import com.sinandogans.readnrent.application.services.book.add.AddBookRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("books")
public class BookController {
    private final BookService bookService;

    public BookController(BookService bookService) {
        this.bookService = bookService;
    }

    @PostMapping(value = "add")
    public IResponse register(@RequestBody AddBookRequest addBookRequest) {
        return bookService.addBook(addBookRequest);
    }
}
