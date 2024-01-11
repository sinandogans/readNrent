package com.sinandogans.readnrent.domain.book;

import com.sinandogans.readnrent.domain.library.ReadType;
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
    @OneToMany(mappedBy = "book")
    private List<UserBook> userBooks = new ArrayList<>();
    @OneToMany(mappedBy = "book")
    private List<Review> reviews = new ArrayList<>();

    public void addReview(Review review) {
        reviews.add(review);
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
