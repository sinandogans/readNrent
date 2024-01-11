package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.book.Review;
import com.sinandogans.readnrent.domain.user.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface ReviewRepository extends JpaRepository<Review, Long> {
    Optional<Review> findByBookAndUser(Book book, User user);
}
