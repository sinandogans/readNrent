package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.book.Author;
import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.book.Category;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Optional;

public interface AuthorRepository extends JpaRepository<Author, Long> {
    Optional<Author> findById(Long id);

    Optional<List<Author>> findByIdIn(List<Long> ids);
}
