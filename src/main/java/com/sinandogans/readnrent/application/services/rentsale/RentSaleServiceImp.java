package com.sinandogans.readnrent.application.services.rentsale;

import com.sinandogans.readnrent.application.repositories.RentSaleBookRepository;
import com.sinandogans.readnrent.application.repositories.RentSaleRepository;
import com.sinandogans.readnrent.application.services.book.BookService;
import com.sinandogans.readnrent.application.services.rentsale.addrentbook.AddRentBookRequest;
import com.sinandogans.readnrent.application.services.rentsale.addsalebook.AddSaleBookRequest;
import com.sinandogans.readnrent.application.services.rentsale.updaterentbook.UpdateRentBookRequest;
import com.sinandogans.readnrent.application.services.rentsale.updatesalebook.UpdateSaleBookRequest;
import com.sinandogans.readnrent.application.services.user.UserService;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.application.shared.response.SuccessResponse;
import com.sinandogans.readnrent.domain.rentandsale.RentSaleBookBase;
import com.sinandogans.readnrent.domain.rentandsale.rent.RentBook;
import com.sinandogans.readnrent.domain.rentandsale.sale.Sale;
import com.sinandogans.readnrent.domain.rentandsale.sale.SaleBook;
import com.sinandogans.readnrent.domain.user.User;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.Objects;

@Service
public class RentSaleServiceImp implements RentSaleService {
    private final UserService userService;
    private final BookService bookService;
    private final RentSaleBookRepository rentSaleBookRepository;
    private final RentSaleRepository rentSaleRepository;

    public RentSaleServiceImp(UserService userService, BookService bookService, RentSaleBookRepository rentSaleBookRepository, RentSaleRepository rentSaleRepository) {
        this.userService = userService;
        this.bookService = bookService;
        this.rentSaleBookRepository = rentSaleBookRepository;
        this.rentSaleRepository = rentSaleRepository;
    }

    @Override
    public IResponse addRentBook(AddRentBookRequest addRentBookRequest) {
        var user = userService.getUserFromJwtToken();
        var book = bookService.getById(addRentBookRequest.getBookId());
        var rentBook = RentBook.create(book, user, addRentBookRequest.getPrice(), addRentBookRequest.getRentDurationWeek());
        rentSaleBookRepository.save(rentBook);

        return new SuccessResponse("rent book eklendi");
    }

    @Override
    public IResponse updateRentBook(UpdateRentBookRequest updateRentBookRequest) {
        var rentBook = (RentBook) getRentOrSaleBook(updateRentBookRequest.getRentBookId());

        checkIfUserCanEdit(rentBook.getUser());

        rentBook.setPrice(updateRentBookRequest.getPrice());
        rentBook.setRentDurationWeek(updateRentBookRequest.getRentDurationWeek());
        rentBook.setLastUpdatedTime(LocalDateTime.now());
        rentSaleBookRepository.save(rentBook);
        return new SuccessResponse("rent book guncellendi");
    }

    @Override
    public IResponse deleteRentBook(Long id) {
        var rentBook = (RentBook) getRentOrSaleBook(id);

        checkIfUserCanEdit(rentBook.getUser());
        rentSaleBookRepository.delete(rentBook);
        return new SuccessResponse("rent book silindi");
    }

    @Override
    public IResponse addSaleBook(AddSaleBookRequest addSaleBookRequest) {
        var user = userService.getUserFromJwtToken();
        var book = bookService.getById(addSaleBookRequest.getBookId());
        var saleBook = SaleBook.create(book, user, addSaleBookRequest.getPrice());
        rentSaleBookRepository.save(saleBook);

        return new SuccessResponse("sale book eklendi");
    }

    @Override
    public IResponse updateSaleBook(UpdateSaleBookRequest updateSaleBookRequest) {
        var saleBook = (SaleBook) getRentOrSaleBook(updateSaleBookRequest.getSaleBookId());

        checkIfUserCanEdit(saleBook.getUser());

        saleBook.setPrice(updateSaleBookRequest.getPrice());
        saleBook.setLastUpdatedTime(LocalDateTime.now());
        rentSaleBookRepository.save(saleBook);
        return new SuccessResponse("sale book guncellendi");
    }

    @Override
    public IResponse deleteSaleBook(Long id) {
        var saleBook = (SaleBook) getRentOrSaleBook(id);

        checkIfUserCanEdit(saleBook.getUser());
        rentSaleBookRepository.delete(saleBook);
        return new SuccessResponse("sale book silindi");
    }

    public RentSaleBookBase getRentOrSaleBook(Long id) {
        var optionalBook = rentSaleBookRepository.findById(id);
        if (optionalBook.isEmpty())
            throw new RuntimeException("boyle bir rent veya sale book yok");
        return optionalBook.get();
    }

    private void checkIfUserCanEdit(User user) {
        var currentUser = userService.getUserFromJwtToken();
        if (!Objects.equals(user.getId(), currentUser.getId()))
            throw new RuntimeException("bu ogeyi guncelleyemezsin");

    }
}
