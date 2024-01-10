package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.library.UserBook;
import com.sinandogans.readnrent.domain.user.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Optional;

public interface UserBookRepository extends JpaRepository<UserBook, Long> {
    Optional<UserBook> findByUserAndBook(User user, Book book);
    Optional<List<UserBook>> findByUser(User user);
}
