package com.sinandogans.readnrent.application.services.rentsale.addsalebook;

import lombok.AllArgsConstructor;
import lombok.Getter;

import java.math.BigDecimal;

@Getter
@AllArgsConstructor
public class AddSaleBookRequest {
    private Long bookId;
    private BigDecimal price;
}
