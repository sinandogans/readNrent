package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.user.FollowedUser;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Optional;

public interface FollowedUserRepository extends JpaRepository<FollowedUser, Long> {
    Optional<List<FollowedUser>> findFollowedUserByFollowedUserId(Long id);
}
