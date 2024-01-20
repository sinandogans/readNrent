package com.sinandogans.readnrent.application.services.library;

import com.sinandogans.readnrent.application.repositories.ReadingGoalRepository;
import com.sinandogans.readnrent.application.repositories.UserBookRepository;
import com.sinandogans.readnrent.application.services.book.BookService;
import com.sinandogans.readnrent.application.services.library.readinggoal.AddReadingGoalRequest;
import com.sinandogans.readnrent.application.services.library.readinggoal.GetReadingGoalsResponse;
import com.sinandogans.readnrent.application.services.library.readinggoal.UpdateReadingGoalRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.AddUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.UpdateUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.responses.GetUserBooksAuthorDTO;
import com.sinandogans.readnrent.application.services.library.userbook.responses.GetUserBooksBookDTO;
import com.sinandogans.readnrent.application.services.library.userbook.responses.GetUserBooksCategoryDTO;
import com.sinandogans.readnrent.application.services.library.userbook.responses.GetUserBooksResponse;
import com.sinandogans.readnrent.application.services.user.UserService;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.application.shared.response.SuccessDataResponse;
import com.sinandogans.readnrent.application.shared.response.SuccessResponse;
import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.library.ReadType;
import com.sinandogans.readnrent.domain.library.ReadingGoal;
import com.sinandogans.readnrent.domain.library.UserBook;
import com.sinandogans.readnrent.domain.user.User;
import org.modelmapper.ModelMapper;
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
    private final ModelMapper modelMapper;


    public LibraryServiceImp(UserService userService, BookService bookService, ReadingGoalRepository readingGoalRepository, UserBookRepository userBookRepository, ModelMapper modelMapper) {
        this.userService = userService;
        this.bookService = bookService;
        this.readingGoalRepository = readingGoalRepository;
        this.userBookRepository = userBookRepository;
        this.modelMapper = modelMapper;
    }

    @Override
    public IResponse addReadingGoal(AddReadingGoalRequest addReadingGoalRequest) {
        var user = userService.getUserFromJwtToken();

        checkIfReadingGoalNotExist(user);

        ReadingGoal readingGoal = modelMapper.map(addReadingGoalRequest, ReadingGoal.class);
        readingGoal.setYear(LocalDate.now().getYear());
        readingGoal.setUser(user);
        readingGoalRepository.save(readingGoal);
        return new SuccessResponse("reading goal eklendi");
    }

    @Override
    public IResponse updateReadingGoal(UpdateReadingGoalRequest updateReadingGoalRequest) {
        var user = userService.getUserFromJwtToken();
        var readingGoal = findReadingGoalByUserAndYear(user, LocalDate.now().getYear());
        readingGoal.setGoal(updateReadingGoalRequest.getGoal());
        readingGoalRepository.save(readingGoal);
        return new SuccessResponse("reading goal güncellendi");
    }

    @Override
    public IResponse deleteReadingGoal() {
        var user = userService.getUserFromJwtToken();
        var readingGoal = findReadingGoalByUserAndYear(user, LocalDate.now().getYear());
        readingGoalRepository.delete(readingGoal);
        return new SuccessResponse("reading goal silindi");
    }

    @Override
    public IResponse addUserBook(AddUserBookRequest addUserBookRequest) {
        UserBook userBook = modelMapper.map(addUserBookRequest, UserBook.class);
        var user = userService.getUserFromJwtToken();
        var book = bookService.getById(addUserBookRequest.getBookId());

        checkIfUserBookNotExistByUserAndBook(user, book);

        userBook.setUser(user);
        userBook.setBook(book);
        userBookRepository.save(userBook);
        //eventPublisher.publishEvent(new UserBookAddedEvent(this, book, user, userBook.getRating(), userBook.isLiked(), userBook.getReview()));

        return new SuccessResponse("user book eklendi");
    }

    @Override
    public IResponse updateUserBook(UpdateUserBookRequest updateUserBookRequest) {
        var user = userService.getUserFromJwtToken();
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
    public IResponse deleteUserBook(Long id) {
        var user = userService.getUserFromJwtToken();
        var book = bookService.getById(id);
        var userBook = getUserBookByUserAndBook(user, book);

        userBookRepository.delete(userBook);
        return new SuccessResponse("user book silindi");
    }

    @Override
    public IDataResponse<List<GetUserBooksResponse>> getUserBooks() {
        var user = userService.getUserFromJwtToken();
        var userBooks = getUserBooksByUser(user);
        List<GetUserBooksResponse> response = new ArrayList<>();
        userBooks.forEach(userBook -> {
            GetUserBooksResponse responseBook = modelMapper.map(userBook, GetUserBooksResponse.class);
            response.add(responseBook);
            responseBook.setBook(
                    new GetUserBooksBookDTO(userBook.getBook().getId(), userBook.getBook().getName(), userBook.getBook().getImagePath(),
                            new GetUserBooksCategoryDTO(userBook.getBook().getCategory().getName()), userBook.getBook().getAuthors().stream().map(
                            author -> new GetUserBooksAuthorDTO(author.getId(), author.getFullName(), author.getImagePath())).toList()));
        });
        return new SuccessDataResponse<>("user booklar geldi", response);
    }

    @Override
    public IDataResponse<List<GetReadingGoalsResponse>> getReadingGoals() {
        var user = userService.getUserFromJwtToken();
        var readingGoals = user.getReadingGoals();
        var readingGoalsResponse = new ArrayList<GetReadingGoalsResponse>();
        readingGoals.forEach(readingGoal -> {
            var yearReadCount = user.getUserBooks().stream().filter(
                            userBook -> userBook.getReadType() == ReadType.READ
                                    && userBook.getFinishDate().getYear() == readingGoal.getYear())
                    .toList().size();

            readingGoalsResponse.add(new GetReadingGoalsResponse(readingGoal.getGoal(), yearReadCount, readingGoal.getYear()));
        });
        return new SuccessDataResponse<>("reading goaller geldi", readingGoalsResponse);
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
