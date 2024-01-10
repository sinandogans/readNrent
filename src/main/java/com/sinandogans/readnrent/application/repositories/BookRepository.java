package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.book.Book;
import org.springframework.data.jpa.repository.JpaRepository;

public interface BookRepository extends JpaRepository<Book, Long> {
}
