package com.sinandogans.readnrent.application.services.book;

import com.sinandogans.readnrent.application.repositories.BookRepository;
import com.sinandogans.readnrent.application.repositories.CategoryRepository;
import com.sinandogans.readnrent.application.repositories.CommentRepository;
import com.sinandogans.readnrent.application.repositories.ReviewRepository;
import com.sinandogans.readnrent.application.services.author.AuthorService;
import com.sinandogans.readnrent.application.services.book.book.add.AddBookRequest;
import com.sinandogans.readnrent.application.services.book.category.AddCategoryRequest;
import com.sinandogans.readnrent.application.services.book.category.UpdateCategoryRequest;
import com.sinandogans.readnrent.application.services.book.book.update.UpdateBookRequest;
import com.sinandogans.readnrent.application.services.book.comment.AddCommentRequest;
import com.sinandogans.readnrent.application.services.book.comment.UpdateCommentRequest;
import com.sinandogans.readnrent.application.services.book.review.AddReviewRequest;
import com.sinandogans.readnrent.application.services.book.review.UpdateReviewRequest;
import com.sinandogans.readnrent.application.services.user.UserService;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.application.shared.response.SuccessResponse;
import com.sinandogans.readnrent.domain.book.Book;
import com.sinandogans.readnrent.domain.book.Category;
import com.sinandogans.readnrent.domain.book.Comment;
import com.sinandogans.readnrent.domain.book.Review;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

@Service
public class BookServiceImp implements BookService {
    private final BookRepository bookRepository;
    private final CategoryRepository categoryRepository;
    private final ReviewRepository reviewRepository;
    private final CommentRepository commentRepository;
    private final AuthorService authorService;
    private final UserService userService;
    private final ModelMapper modelMapper;

    public BookServiceImp(BookRepository bookRepository, CategoryRepository categoryRepository, ReviewRepository reviewRepository, CommentRepository commentRepository, AuthorService authorService, UserService userService, ModelMapper modelMapper) {
        this.bookRepository = bookRepository;
        this.categoryRepository = categoryRepository;
        this.reviewRepository = reviewRepository;
        this.commentRepository = commentRepository;
        this.authorService = authorService;
        this.userService = userService;
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
    public void updateBook(Book book) {
        bookRepository.save(book);
    }

    @Override
    public IResponse addBook(AddBookRequest addBookRequest) {
        Book book = modelMapper.map(addBookRequest, Book.class);
        book.setId(null);
        book.setCategory(getCategoryById(addBookRequest.getCategoryId()));
        book.setAuthors(authorService.getByIds(addBookRequest.getAuthorIds()));
        bookRepository.save(book);
        return new SuccessResponse("kitap eklendi");
    }

    @Override
    public IResponse updateBook(UpdateBookRequest updateBookRequest) {
        var book = getById(updateBookRequest.getId());
        var id = book.getId();
        var userBooks = book.getUserBooks();
        book = modelMapper.map(updateBookRequest, Book.class);

        book.setId(id);
        book.setUserBooks(userBooks);
        book.setCategory(getCategoryById(updateBookRequest.getId()));
        book.setAuthors(authorService.getByIds(updateBookRequest.getAuthorIds()));
        bookRepository.save(book);
        return new SuccessResponse("kitap guncellendi");
    }

    @Override
    public IResponse deleteBook(Long id) {
        var book = getById(id);
        bookRepository.delete(book);
        return new SuccessResponse("kitap silindi");
    }

    @Override
    public IResponse addCategory(AddCategoryRequest addCategoryRequest) {
        checkIfCategoryAlreadyExist(addCategoryRequest.getName());
        Category category = modelMapper.map(addCategoryRequest, Category.class);

        categoryRepository.save(category);
        return new SuccessResponse("category eklendi");
    }

    @Override
    public IResponse updateCategory(UpdateCategoryRequest updateCategoryRequest) {
        checkIfCategoryAlreadyExist(updateCategoryRequest.getName());
        var category = getCategoryById(updateCategoryRequest.getId());
        category.setName(updateCategoryRequest.getName());

        categoryRepository.save(category);
        return new SuccessResponse("category guncellendi");
    }

    @Override
    public IResponse deleteCategory(Long id) {
        var category = getCategoryById(id);
        categoryRepository.delete(category);
        return new SuccessResponse("category silindi");
    }

    @Override
    public IResponse addReview(AddReviewRequest addReviewRequest) {
        var user = userService.getUserFromJwtToken();
        var book = getById(addReviewRequest.getBookId());
        var reviewToAdd = Review.createReview(book, user, addReviewRequest.getText());
        book.addReview(reviewToAdd);
        reviewRepository.save(reviewToAdd);
        return new SuccessResponse("review eklendi");
    }

    @Override
    public IResponse updateReview(UpdateReviewRequest updateReviewRequest) {
        var review = getReviewById(updateReviewRequest.getReviewId());
        review.setText(updateReviewRequest.getText());
        reviewRepository.save(review);
        return new SuccessResponse("review guncellendi");
    }

    @Override
    public IResponse deleteReview(Long id) {
        var review = getReviewById(id);
        review.getBook().removeReview(review);
        reviewRepository.delete(review);
        return new SuccessResponse("review silindi");
    }

    @Override
    public IResponse likeReview(Long reviewId) {
        var user = userService.getUserFromJwtToken();
        var review = getReviewById(reviewId);
        review.like(user);
        user.likeReview(review);
        reviewRepository.save(review);
        return new SuccessResponse("islem basarili");
    }

    @Override
    public IResponse likeComment(Long commentId) {
        var user = userService.getUserFromJwtToken();
        var comment = getCommentById(commentId);
        comment.like(user);
        user.likeComment(comment);
        commentRepository.save(comment);
        return new SuccessResponse("islem basarili");
    }

    @Override
    public IResponse addComment(AddCommentRequest addCommentRequest) {
        var user = userService.getUserFromJwtToken();
        var review = getReviewById(addCommentRequest.getReviewId());
        var comment = Comment.createComment(review, user, addCommentRequest.getText());
        review.addComment(comment);
        commentRepository.save(comment);
        return new SuccessResponse("comment eklendi");
    }

    @Override
    public IResponse updateComment(UpdateCommentRequest updateCommentRequest) {
        var comment = getCommentById(updateCommentRequest.getCommentId());
        comment.setText(updateCommentRequest.getText());
        commentRepository.save(comment);
        return new SuccessResponse("comment guncellendi");
    }

    @Override
    public IResponse deleteComment(Long id) {
        var comment = getCommentById(id);
        comment.getReview().removeComment(comment);
        commentRepository.delete(comment);
        return new SuccessResponse("comment silindi");
    }


//    private void checkIfUserNotHaveReviewToBook(Book book, User user) {
//        var optionalReview = reviewRepository.findByBookAndUser(book, user);
//        if (optionalReview.isPresent())
//            throw new RuntimeException("bu kitaba incelemen var zaten");
//
//    }

    @Override
    public Category getCategoryById(Long id) {
        var optionalCategory = categoryRepository.findById(id);
        if (optionalCategory.isEmpty())
            throw new RuntimeException("category yok");
        return optionalCategory.get();
    }

    @Override
    public Category getCategoryByName(String name) {
        var optionalCategory = categoryRepository.findByName(name);
        if (optionalCategory.isEmpty())
            throw new RuntimeException("category yok");
        return optionalCategory.get();
    }

    @Override
    public Review getReviewById(Long id) {
        var optionalReview = reviewRepository.findById(id);
        if (optionalReview.isEmpty())
            throw new RuntimeException("review yok");
        return optionalReview.get();
    }

    @Override
    public Comment getCommentById(Long id) {
        var optionalComment = commentRepository.findById(id);
        if (optionalComment.isEmpty())
            throw new RuntimeException("comment yok");
        return optionalComment.get();
    }

    private void checkIfCategoryAlreadyExist(String name) {
        var optionalCategory = categoryRepository.findByName(name);
        if (optionalCategory.isPresent())
            throw new RuntimeException("category zaten var");
    }

//    private void checkIfReviewExistByBookAndUser(Book book, User user) {
//        var review = reviewRepository.findByBookAndUser(book, user);
//        if (review.isPresent())
//            throw new RuntimeException("review zaten var");
//
//    }
}
