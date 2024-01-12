package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.user.BlockedUser;
import org.springframework.data.jpa.repository.JpaRepository;

public interface BlockedUserRepository extends JpaRepository<BlockedUser, Long> {
}
