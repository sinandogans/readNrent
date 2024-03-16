package com.sinandogans.readnrent.application.services.rentsale;

import com.sinandogans.readnrent.application.services.rentsale.addrentbook.AddRentBookRequest;
import com.sinandogans.readnrent.application.services.rentsale.addsalebook.AddSaleBookRequest;
import com.sinandogans.readnrent.application.services.rentsale.updaterentbook.UpdateRentBookRequest;
import com.sinandogans.readnrent.application.services.rentsale.updatesalebook.UpdateSaleBookRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;

public interface RentSaleService {

    IResponse addRentBook(AddRentBookRequest addRentBookRequest);

    IResponse updateRentBook(UpdateRentBookRequest updateRentBookRequest);

    IResponse deleteRentBook(Long id);

    IResponse addSaleBook(AddSaleBookRequest addSaleBookRequest);

    IResponse updateSaleBook(UpdateSaleBookRequest updateSaleBookRequest);

    IResponse deleteSaleBook(Long id);
}
