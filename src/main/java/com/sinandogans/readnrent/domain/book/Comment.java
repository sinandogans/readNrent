package com.sinandogans.readnrent.domain.book;

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
public class Comment {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String text;
    @ManyToOne
    private Review review;
    @OneToOne
    private User user;
    @ManyToMany
    private List<User> usersLiked = new ArrayList<>();

    public static Comment createComment(Review review, User user, String text) {
        return new Comment(null, text, review, user, new ArrayList<>());
    }

    public void like(User user){
        var index = usersLiked.indexOf(user);
        if (index == -1)
            usersLiked.add(user);
        else
            usersLiked.remove(index);
    }
}
