package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.user.Follow;
import org.springframework.data.jpa.repository.JpaRepository;

public interface FollowRepository extends JpaRepository<Follow, Long> {
//    Optional<List<Follow>> findFollowedUserByFollowedUserId(Long id);
}
