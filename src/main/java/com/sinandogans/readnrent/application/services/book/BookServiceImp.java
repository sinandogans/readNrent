package com.sinandogans.readnrent.application.services.book;

import com.sinandogans.readnrent.application.repositories.BookRepository;
import com.sinandogans.readnrent.application.repositories.CategoryRepository;
import com.sinandogans.readnrent.application.repositories.ReviewRepository;
import com.sinandogans.readnrent.application.services.author.AuthorService;
import com.sinandogans.readnrent.application.services.book.add.AddBookRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.application.shared.response.SuccessResponse;
import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.book.Category;
import com.sinandogans.readnrent.domain.book.Review;
import com.sinandogans.readnrent.domain.user.User;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

@Service
public class BookServiceImp implements BookService {
    private final BookRepository bookRepository;
    private final ReviewRepository reviewRepository;
    private final CategoryRepository categoryRepository;
    private final AuthorService authorService;
    private final ModelMapper modelMapper;

    public BookServiceImp(BookRepository bookRepository, ReviewRepository reviewRepository, CategoryRepository categoryRepository, AuthorService authorService, ModelMapper modelMapper) {
        this.bookRepository = bookRepository;
        this.reviewRepository = reviewRepository;
        this.categoryRepository = categoryRepository;
        this.authorService = authorService;
        this.modelMapper = modelMapper;
    }

    @Override
    public Book getById(Long id) {
        var optionalBook = bookRepository.findById(id);
        if (optionalBook.isEmpty())
            throw new RuntimeException("book id yok");
        return optionalBook.get();
    }

    @Override
    public void addReview(Review review) {
        checkIfReviewExistByBookAndUser(review.getBook(), review.getUser());
        reviewRepository.save(review);
    }

    @Override
    public void updateBook(Book book) {
        bookRepository.save(book);
    }

    @Override
    public IResponse addBook(AddBookRequest addBookRequest) {
        Book book = modelMapper.map(addBookRequest, Book.class);
        book.setCategory(getCategoryById(addBookRequest.getCategoryId()));
        book.setAuthors(authorService.getByIds(addBookRequest.getAuthorIds()));
        bookRepository.save(book);
        return new SuccessResponse("kitap eklendi");
    }

    @Override
    public Category getCategoryById(Long id) {
        var optionalCategory = categoryRepository.findById(id);
        if (optionalCategory.isEmpty())
            throw new RuntimeException("category yok");
        return optionalCategory.get();
    }

    private void checkIfReviewExistByBookAndUser(Book book, User user) {
        var review = reviewRepository.findByBookAndUser(book, user);
        if (review.isPresent())
            throw new RuntimeException("review zaten var");

    }
}
