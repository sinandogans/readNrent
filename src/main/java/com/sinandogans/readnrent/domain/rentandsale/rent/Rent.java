package com.sinandogans.readnrent.domain.rentandsale.rent;

import com.sinandogans.readnrent.domain.rentandsale.RentSaleBase;
import com.sinandogans.readnrent.domain.user.Address;
import jakarta.persistence.Entity;
import jakarta.persistence.ManyToOne;
import lombok.Getter;
import lombok.Setter;

@Entity
@Getter
@Setter
public class Rent extends RentSaleBase {
    private int rentWeek;
    private boolean isReturned;
    @ManyToOne
    private Address senderAddress;
}
