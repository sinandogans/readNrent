package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.book.Category;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Optional;

public interface CategoryRepository extends JpaRepository<Category, Long> {
    Optional<Category> findById(Long id);

    Optional<List<Category>> findAllByIdIn(List<Long> ids);

    Optional<Category> findByName(String name);
}
