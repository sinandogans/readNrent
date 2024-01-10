package com.sinandogans.readnrent.application.events.userbook;

import org.springframework.context.ApplicationEvent;

public class UserBookAddedEvent extends ApplicationEvent {
    private double rating;
    private boolean liked;
    private String review;

    public UserBookAddedEvent(Object source, double rating, boolean liked, String review) {
        super(source);
        this.rating = rating;
        this.liked = liked;
        this.review = review;
    }
}
