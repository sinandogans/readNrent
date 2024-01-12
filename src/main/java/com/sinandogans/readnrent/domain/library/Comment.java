package com.sinandogans.readnrent.domain.library;

import com.sinandogans.readnrent.domain.book.Review;
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
    @ManyToMany(mappedBy = "comments")
    private List<User> usersLiked = new ArrayList<>();
}
