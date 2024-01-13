package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.rentandsale.RentSaleBookBase;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface RentSaleBookRepository extends JpaRepository<RentSaleBookBase, Long> {
    Optional<RentSaleBookBase> findById(Long id);
}
