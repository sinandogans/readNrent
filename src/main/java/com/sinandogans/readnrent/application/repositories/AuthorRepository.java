package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.book.Author;
import org.springframework.data.jpa.repository.JpaRepository;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

public interface AuthorRepository extends JpaRepository<Author, Long> {
    Optional<Author> findById(Long id);

    Optional<List<Author>> findByIdIn(List<Long> ids);

    Optional<Author> findByFirstNameAndLastNameAndBirthDate(String firstName, String lastName, LocalDate birthDate);
}
