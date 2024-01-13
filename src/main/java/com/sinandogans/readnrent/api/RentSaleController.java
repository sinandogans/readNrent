package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.repositories.RentSaleBookRepository;
import com.sinandogans.readnrent.application.services.author.AuthorService;
import com.sinandogans.readnrent.application.services.author.add.AddAuthorRequest;
import com.sinandogans.readnrent.application.services.author.update.UpdateAuthorRequest;
import com.sinandogans.readnrent.application.services.book.BookService;
import com.sinandogans.readnrent.application.services.user.UserService;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.domain.rentandsale.rent.RentBook;
import org.springframework.web.bind.annotation.*;

import java.math.BigDecimal;

@RestController
@RequestMapping("rents")
public class RentSaleController {

    private final RentSaleBookRepository rentSaleBookRepository;
    private final UserService userService;
    private final BookService bookService;

    public RentSaleController(RentSaleBookRepository rentSaleBookRepository, UserService userService, BookService bookService) {
        this.rentSaleBookRepository = rentSaleBookRepository;
        this.userService = userService;
        this.bookService = bookService;
    }

    @PostMapping(value = "add")
    public IResponse register() {
        var rentBook = new RentBook();
        rentBook.setUser(userService.getUserFromJwtToken());
        rentBook.setBook(bookService.getById(1L));
        rentBook.setPrice(BigDecimal.valueOf(10l));
        rentSaleBookRepository.save(rentBook);
        return null;
    }
}
