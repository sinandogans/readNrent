package com.sinandogans.readnrent.domain.rentandsale.sale;

import com.sinandogans.readnrent.domain.rentandsale.RentSaleBookBase;
import com.sinandogans.readnrent.domain.rentandsale.rent.Rent;
import jakarta.persistence.Entity;
import jakarta.persistence.OneToMany;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

@Entity
@Getter
@Setter
public class SaleBook extends RentSaleBookBase {

}
