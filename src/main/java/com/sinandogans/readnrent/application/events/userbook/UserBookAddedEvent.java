package com.sinandogans.readnrent.application.events.userbook;

import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.user.User;
import lombok.Getter;
import org.springframework.context.ApplicationEvent;

@Getter
public class UserBookAddedEvent extends ApplicationEvent {
    private Book book;
    private User user;
    private double rating;
    private boolean liked;
    private String review;

    public UserBookAddedEvent(Object source, Book book, User user, double rating, boolean liked, String review) {
        super(source);
        this.book = book;
        this.user = user;
        this.rating = rating;
        this.liked = liked;
        this.review = review;
    }
}
