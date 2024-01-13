package com.sinandogans.readnrent.application.services.rentsale.addrentbook;

import lombok.AllArgsConstructor;
import lombok.Getter;

import java.math.BigDecimal;

@Getter
@AllArgsConstructor
public class AddRentBookRequest {
    private Long bookId;
    private BigDecimal price;
    private int rentDurationWeek;
}
