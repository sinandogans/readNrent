package com.sinandogans.readnrent.domain.rentandsale.sale;

import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.rentandsale.RentSaleBookBase;
import com.sinandogans.readnrent.domain.rentandsale.rent.Rent;
import com.sinandogans.readnrent.domain.rentandsale.rent.RentBook;
import com.sinandogans.readnrent.domain.user.User;
import jakarta.persistence.Entity;
import jakarta.persistence.OneToMany;
import jakarta.persistence.OneToOne;
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
public class SaleBook extends RentSaleBookBase {
    @OneToOne(mappedBy = "saleBook")
    private Sale sale;

    private SaleBook(Book book, User user, BigDecimal price) {
        super(null, book, user, price, LocalDateTime.now(), LocalDateTime.now());
    }

    public static SaleBook create(Book book, User user, BigDecimal price) {
        return new SaleBook(book, user, price);
    }
}
