package com.sinandogans.readnrent.application.services.rentsale.updatesalebook;

import lombok.AllArgsConstructor;
import lombok.Getter;

import java.math.BigDecimal;

@Getter
@AllArgsConstructor
public class UpdateSaleBookRequest {
    private Long saleBookId;
    private BigDecimal price;
}
