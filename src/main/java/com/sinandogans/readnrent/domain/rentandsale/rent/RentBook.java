package com.sinandogans.readnrent.domain.rentandsale.rent;

import com.sinandogans.readnrent.domain.rentandsale.RentSaleBookBase;
import jakarta.persistence.Entity;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class RentBook extends RentSaleBookBase {
    private int rentDurationWeek;
}
