package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.library.ReadingGoal;
import com.sinandogans.readnrent.domain.user.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface ReadingGoalRepository extends JpaRepository<ReadingGoal, Long> {
    Optional<ReadingGoal> findByUserAndYear(User user, int year);
}
