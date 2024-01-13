package com.sinandogans.readnrent.application.repositories;

import com.sinandogans.readnrent.domain.rentandsale.RentSaleBase;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface RentSaleRepository extends JpaRepository<RentSaleBase, Long> {
    Optional<RentSaleBase> findById(Long id);
}
