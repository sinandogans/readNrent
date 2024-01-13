package com.sinandogans.readnrent.domain.rentandsale.rent;

import com.sinandogans.readnrent.domain.rentandsale.RentSaleBase;
import jakarta.persistence.Entity;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Getter
@Setter
public class Rent extends RentSaleBase {
    private int rentWeek;
}
