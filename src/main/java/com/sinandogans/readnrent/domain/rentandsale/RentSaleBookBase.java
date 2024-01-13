package com.sinandogans.readnrent.domain.rentandsale;

import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.user.User;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Inheritance(strategy = InheritanceType.JOINED)
public class RentSaleBookBase {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @ManyToOne
    private Book book;
    @ManyToOne
    private User user;
    @OneToMany(mappedBy = "rentSaleBook")
    private List<RentSaleBase> rentAndSales = new ArrayList<>();
    private BigDecimal price;
    private LocalDateTime publishedTime;
}
