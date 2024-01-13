package com.sinandogans.readnrent.domain.rentandsale.sale;

import com.sinandogans.readnrent.domain.rentandsale.RentSaleBase;
import com.sinandogans.readnrent.domain.rentandsale.rent.RentBook;
import com.sinandogans.readnrent.domain.user.User;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDateTime;

@Entity
@Getter
@Setter
public class Sale extends RentSaleBase {
    @OneToOne
    private SaleBook saleBook;
}
