package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.book.Category;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface CategoryRepository extends JpaRepository<Category, Long> {
    Optional<Category> findById(Long id);
}
