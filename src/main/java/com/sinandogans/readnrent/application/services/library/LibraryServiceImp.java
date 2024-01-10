package com.sinandogans.readnrent.application.services.library;

import com.sinandogans.readnrent.application.events.userbook.UserBookAddedEvent;
import com.sinandogans.readnrent.application.repositories.ReadingGoalRepository;
import com.sinandogans.readnrent.application.repositories.UserBookRepository;
import com.sinandogans.readnrent.application.security.jwt.JwtService;
import com.sinandogans.readnrent.application.services.book.BookService;
import com.sinandogans.readnrent.application.services.library.readinggoal.AddReadingGoalRequest;
import com.sinandogans.readnrent.application.services.library.readinggoal.UpdateReadingGoalRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.AddUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.DeleteUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.UpdateUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.responses.GetUserBooksResponse;
import com.sinandogans.readnrent.application.services.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.services.shared.response.IResponse;
import com.sinandogans.readnrent.application.services.shared.response.SuccessDataResponse;
import com.sinandogans.readnrent.application.services.shared.response.SuccessResponse;
import com.sinandogans.readnrent.application.services.user.UserService;
import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.library.ReadingGoal;
import com.sinandogans.readnrent.domain.library.UserBook;
import com.sinandogans.readnrent.domain.user.User;
import jakarta.servlet.http.HttpServletRequest;
import org.modelmapper.ModelMapper;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Service
public class LibraryServiceImp implements LibraryService {
    private final UserService userService;
    private final BookService bookService;
    private final ReadingGoalRepository readingGoalRepository;
    private final UserBookRepository userBookRepository;
    private final JwtService jwtService;
    private final ModelMapper modelMapper;
    private HttpServletRequest request;
    private final ApplicationEventPublisher eventPublisher;


    public LibraryServiceImp(UserService userService, BookService bookService, ReadingGoalRepository readingGoalRepository, UserBookRepository userBookRepository, JwtService jwtService, ModelMapper modelMapper, HttpServletRequest request, ApplicationEventPublisher eventPublisher) {
        this.userService = userService;
        this.bookService = bookService;
        this.readingGoalRepository = readingGoalRepository;
        this.userBookRepository = userBookRepository;
        this.jwtService = jwtService;
        this.modelMapper = modelMapper;
        this.request = request;
        this.eventPublisher = eventPublisher;
    }

    @Override
    public IResponse addReadingGoal(AddReadingGoalRequest addReadingGoalRequest) {
        var user = getUserFromJwtToken();

        checkIfReadingGoalNotExist(user);

        ReadingGoal readingGoal = modelMapper.map(addReadingGoalRequest, ReadingGoal.class);
        readingGoal.setYear(LocalDate.now().getYear());
        readingGoal.setUser(user);
        readingGoalRepository.save(readingGoal);
        return new SuccessResponse("reading goal eklendi");
    }

    @Override
    public IResponse updateReadingGoal(UpdateReadingGoalRequest updateReadingGoalRequest) {
        var user = getUserFromJwtToken();
        var readingGoal = findReadingGoalByUserAndYear(user, LocalDate.now().getYear());
        readingGoal.setGoal(updateReadingGoalRequest.getGoal());
        readingGoalRepository.save(readingGoal);
        return new SuccessResponse("reading goal güncellendi");
    }

    @Override
    public IResponse deleteReadingGoal() {
        var user = getUserFromJwtToken();
        var readingGoal = findReadingGoalByUserAndYear(user, LocalDate.now().getYear());
        readingGoalRepository.delete(readingGoal);
        return new SuccessResponse("reading goal silindi");
    }

    @Override
    public IResponse addUserBook(AddUserBookRequest addUserBookRequest) {
        UserBook userBook = modelMapper.map(addUserBookRequest, UserBook.class);
        var user = getUserFromJwtToken();
        var book = bookService.getById(addUserBookRequest.getBookId());

        checkIfUserBookNotExistByUserAndBook(user, book);

        userBook.setUser(user);
        userBook.setBook(book);
        userBookRepository.save(userBook);
        eventPublisher.publishEvent(new UserBookAddedEvent(this, userBook.getRating(), userBook.isLiked(), userBook.getReview()));

        return new SuccessResponse("user book eklendi");
    }

    @Override
    public IResponse updateUserBook(UpdateUserBookRequest updateUserBookRequest) {
        var user = getUserFromJwtToken();
        var book = bookService.getById(updateUserBookRequest.getBookId());
        var userBook = getUserBookByUserAndBook(user, book);
        var id = userBook.getId();
        userBook = modelMapper.map(updateUserBookRequest, UserBook.class);
        userBook.setBook(book);
        userBook.setUser(user);
        userBook.setId(id);
        userBookRepository.save(userBook);
        return new SuccessResponse("user book guncellendi");
    }

    @Override
    public IResponse deleteUserBook(DeleteUserBookRequest deleteUserBookRequest) {
        var user = getUserFromJwtToken();
        var book = bookService.getById(deleteUserBookRequest.getBookId());
        var userBook = getUserBookByUserAndBook(user, book);

        userBookRepository.delete(userBook);
        return new SuccessResponse("user book silindi");
    }

    @Override
    public IDataResponse<List<GetUserBooksResponse>> getUserBooks() {
        var user = getUserFromJwtToken();
        var userBooks = getUserBooksByUser(user);
        List<GetUserBooksResponse> response = new ArrayList<>();
        userBooks.stream().forEach(userBook -> {
            GetUserBooksResponse responseBook = modelMapper.map(userBook, GetUserBooksResponse.class);
            response.add(responseBook);
        });
        return new SuccessDataResponse<>("user booklar geldi", response);
    }

    private void checkIfUserBookNotExistByUserAndBook(User user, Book book) {
        var optionalUserBook = userBookRepository.findByUserAndBook(user, book);
        if (optionalUserBook.isPresent())
            throw new RuntimeException("user book zaten var");
    }

    public UserBook getUserBookByUserAndBook(User user, Book book) {
        var optionalUserBook = userBookRepository.findByUserAndBook(user, book);
        if (optionalUserBook.isEmpty())
            throw new RuntimeException("user book yok");
        return optionalUserBook.get();
    }

    public List<UserBook> getUserBooksByUser(User user) {
        var optionalUserBooks = userBookRepository.findByUser(user);
        if (optionalUserBooks.isEmpty())
            throw new RuntimeException("user book yok");
        return optionalUserBooks.get();
    }

    public User getUserFromJwtToken() {
        String email = jwtService.getEmail(request);
        return userService.getByEmail(email);
    }

    private ReadingGoal findReadingGoalByUserAndYear(User user, int year) {
        var optionalReadingGoal = readingGoalRepository.findByUserAndYear(user, year);
        if (optionalReadingGoal.isEmpty())
            throw new RuntimeException("reading goal yok");
        return optionalReadingGoal.get();
    }

    private void checkIfReadingGoalNotExist(User user) {
        var optionalReadingGoal = readingGoalRepository.findByUserAndYear(user, LocalDate.now().getYear());
        if (optionalReadingGoal.isPresent())
            throw new RuntimeException("reading goal zaten var");
    }
}
