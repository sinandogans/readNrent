package com.sinandogans.readnrent.domain.book;

import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.library.Comment;
import com.sinandogans.readnrent.domain.user.User;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.util.ArrayList;
import java.util.List;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class Review {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @ManyToOne
    private Book book;
    private String text;
    @ManyToOne
    private User user;
    @ManyToMany(mappedBy = "reviewsLiked")
    private List<User> usersLiked = new ArrayList<>();
    @OneToMany(mappedBy = "review")
    private List<Comment> comments = new ArrayList<>();

    public static Review createReview(Book book, User user, String text) {
        return new Review(null, book, text, user, new ArrayList<>(), new ArrayList<>());
    }
}
