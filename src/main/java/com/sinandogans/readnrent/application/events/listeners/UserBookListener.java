package com.sinandogans.readnrent.application.events.listeners;

import com.sinandogans.readnrent.application.services.book.BookService;
import org.springframework.stereotype.Component;

@Component
public class UserBookListener {
    private final BookService bookService;

    public UserBookListener(BookService bookService) {
        this.bookService = bookService;
    }

//    @EventListener
//    void handleUserBookAddedEvent(UserBookAddedEvent event) {
//        var book = event.getBook();
//        var user = event.getUser();
//        if (!event.getReview().isEmpty()) {
//            var review = new Review(null, book, user, event.getReview());
//            bookService.addReview(review);
//        }
//        bookService.updateBook(book);
//    }
}
