package com.sinandogans.readnrent.domain.rentandsale.rent;

import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.rentandsale.RentSaleBase;
import com.sinandogans.readnrent.domain.rentandsale.RentSaleBookBase;
import com.sinandogans.readnrent.domain.user.User;
import jakarta.persistence.Entity;
import jakarta.persistence.OneToMany;
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
public class RentBook extends RentSaleBookBase {
    private int rentDurationWeek;
    @OneToMany(mappedBy = "rentBook")
    private List<Rent> rents = new ArrayList<>();

    private RentBook(Book book, User user, BigDecimal price, int rentDurationWeek) {
        super(null, book, user, price, LocalDateTime.now(), LocalDateTime.now());
        this.rentDurationWeek = rentDurationWeek;
    }

    public static RentBook create(Book book, User user, BigDecimal price, int rentDurationWeek) {
        return new RentBook(book, user, price, rentDurationWeek);
    }
}
