package com.sinandogans.readnrent.domain.rentandsale;

import com.sinandogans.readnrent.domain.user.Address;
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
@AllArgsConstructor
@NoArgsConstructor
@Inheritance(strategy = InheritanceType.JOINED)
public class RentSaleBase {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @ManyToOne
    private RentSaleBookBase rentSaleBook;
    @ManyToOne
    private User user;
    private boolean isPayed;
    private LocalDateTime operationTime;
    @ManyToOne
    private Address buyerAddress;
}
