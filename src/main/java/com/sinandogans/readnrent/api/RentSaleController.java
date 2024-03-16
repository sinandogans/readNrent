package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.services.rentsale.RentSaleService;
import com.sinandogans.readnrent.application.services.rentsale.addrentbook.AddRentBookRequest;
import com.sinandogans.readnrent.application.services.rentsale.addsalebook.AddSaleBookRequest;
import com.sinandogans.readnrent.application.services.rentsale.updaterentbook.UpdateRentBookRequest;
import com.sinandogans.readnrent.application.services.rentsale.updatesalebook.UpdateSaleBookRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("rents")
public class RentSaleController {

    private final RentSaleService rentSaleService;

    public RentSaleController(RentSaleService rentSaleService) {
        this.rentSaleService = rentSaleService;
    }

    @PostMapping(value = "add-rentbook")
    public IResponse addRentBook(@RequestBody AddRentBookRequest addRentBookRequest) {
        return rentSaleService.addRentBook(addRentBookRequest);
    }

    @PutMapping(value = "update-rentbook")
    public IResponse updateRentBook(@RequestBody UpdateRentBookRequest updateRentBookRequest) {
        return rentSaleService.updateRentBook(updateRentBookRequest);
    }

    @DeleteMapping(value = "delete-rentbook")
    public IResponse deleteRentBook(@RequestParam Long id) {
        return rentSaleService.deleteRentBook(id);
    }


    @PostMapping(value = "add-salebook")
    public IResponse addSaleBook(@RequestBody AddSaleBookRequest addSaleBookRequest) {
        return rentSaleService.addSaleBook(addSaleBookRequest);
    }

    @PutMapping(value = "update-salebook")
    public IResponse updateSaleBook(@RequestBody UpdateSaleBookRequest updateSaleBookRequest) {
        return rentSaleService.updateSaleBook(updateSaleBookRequest);
    }

    @DeleteMapping(value = "delete-salebook")
    public IResponse deleteSaleBook(@RequestParam Long id) {
        return rentSaleService.deleteSaleBook(id);
    }
}
