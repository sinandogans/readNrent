package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.book.Comment;
import com.sinandogans.readnrent.domain.book.Review;
import com.sinandogans.readnrent.domain.user.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface CommentRepository extends JpaRepository<Comment, Long> {
    Optional<Comment> findByReviewAndUser(Review review, User user);
    Optional<Comment> findById(Long id);
}
