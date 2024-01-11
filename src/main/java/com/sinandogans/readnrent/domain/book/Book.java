package com.sinandogans.readnrent.domain.book;

import com.sinandogans.readnrent.domain.library.ReadType;
import com.sinandogans.readnrent.domain.library.Review;
import com.sinandogans.readnrent.domain.library.UserBook;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class Book {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String name;
    private String description;
    private int pages;
    private String publisher;
    private LocalDate publicationDate;
    @ManyToMany
    private List<Author> authors = new ArrayList<>();
    @ManyToOne
    private Category category;
    @OneToMany(mappedBy = "book", cascade = CascadeType.REMOVE)
    private List<UserBook> userBooks = new ArrayList<>();

    public List<Review> getReviews() {
        return userBooks.stream().filter(userBook -> userBook.getReview() != null).map(userBook -> userBook.getReview()).toList();
    }

    public int getLikeCount() {
        return (int) userBooks.stream().filter(userBook -> userBook.isLiked()).count();
    }

    public int getReadCount() {
        return (int) userBooks.stream().filter(userBook -> userBook.getReadType() == ReadType.READ).count();
    }

    public double getRating() {
        var filteredRatings = userBooks.stream().filter(userBook -> userBook.getRating() != 0).map(userBook -> userBook.getRating()).toList();
        return filteredRatings.stream().mapToDouble(Double::doubleValue).sum()
                / filteredRatings.size();
    }

}
