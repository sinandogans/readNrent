package com.sinandogans.readnrent.application.services.rentsale.updaterentbook;

import lombok.AllArgsConstructor;
import lombok.Getter;

import java.math.BigDecimal;

@Getter
@AllArgsConstructor
public class UpdateRentBookRequest {
    private Long rentBookId;
    private BigDecimal price;
    private int rentDurationWeek;
}
