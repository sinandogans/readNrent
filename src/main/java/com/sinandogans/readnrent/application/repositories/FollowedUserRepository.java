package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.user.FollowedUser;
import org.springframework.data.jpa.repository.JpaRepository;

public interface FollowedUserRepository extends JpaRepository<FollowedUser, Long> {
}
