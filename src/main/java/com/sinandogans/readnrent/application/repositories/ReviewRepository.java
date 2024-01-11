package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.library.Review;
import com.sinandogans.readnrent.domain.library.UserBook;
import com.sinandogans.readnrent.domain.user.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface ReviewRepository extends JpaRepository<Review, Long> {
    Optional<Review> findByUserBook(UserBook userBook);
}
