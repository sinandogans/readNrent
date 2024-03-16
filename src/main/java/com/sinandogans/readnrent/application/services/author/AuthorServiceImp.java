package com.sinandogans.readnrent.application.services.author;

import com.sinandogans.readnrent.application.repositories.AuthorRepository;
import com.sinandogans.readnrent.application.services.author.add.AddAuthorRequest;
import com.sinandogans.readnrent.application.services.author.get.GetAuthorsResponseModel;
import com.sinandogans.readnrent.application.services.author.update.UpdateAuthorRequest;
import com.sinandogans.readnrent.application.services.book.category.GetCategoriesResponseModel;
import com.sinandogans.readnrent.application.shared.file.FileService;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.application.shared.response.SuccessDataResponse;
import com.sinandogans.readnrent.application.shared.response.SuccessResponse;
import com.sinandogans.readnrent.domain.book.Author;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AuthorServiceImp implements AuthorService {
    public static String imagePath = "authors/";

    private final AuthorRepository authorRepository;
    private final ModelMapper modelMapper;
    private final FileService fileService;

    public AuthorServiceImp(AuthorRepository authorRepository, ModelMapper modelMapper, FileService fileService) {
        this.authorRepository = authorRepository;
        this.modelMapper = modelMapper;
        this.fileService = fileService;
    }

    @Override
    public Author getById(Long id) {
        var optionalAuthor = authorRepository.findById(id);
        if (optionalAuthor.isEmpty())
            throw new RuntimeException("author yok");
        return optionalAuthor.get();
    }

    @Override
    public List<Author> getByIds(List<Long> ids) {
        var optionalAuthor = authorRepository.findByIdIn(ids);
        if (optionalAuthor.isEmpty())
            throw new RuntimeException("author yok");
        return optionalAuthor.get();
    }

    @Override
    public IResponse addAuthor(AddAuthorRequest addAuthorRequest) {
        var authorToAdd = modelMapper.map(addAuthorRequest, Author.class);
        checkIfAuthorAlreadyExist(authorToAdd);
        var dbSavePath = fileService.createAndSaveFile(addAuthorRequest.getPhoto(), imagePath, authorToAdd.getFullName());
        authorToAdd.setImagePath(dbSavePath);
        authorRepository.save(authorToAdd);
        return new SuccessResponse("author eklendi");
    }

    @Override
    public IResponse updateAuthor(UpdateAuthorRequest updateAuthorRequest) {
        var author = getById(updateAuthorRequest.getId());
        var id = author.getId();
        var books = author.getBooks();
        author = modelMapper.map(updateAuthorRequest, Author.class);

        author.setId(id);
        author.setBooks(books);
        authorRepository.save(author);
        return new SuccessResponse("author guncellendi");
    }

    @Override
    public IResponse deleteAuthor(Long id) {
        var author = getById(id);
        authorRepository.delete(author);
        return new SuccessResponse("author silindi");
    }

    @Override
    public IDataResponse<List<GetAuthorsResponseModel>> getAll() {
        var authors = authorRepository.findAll();
        var getAuthorsResponse = authors.stream().map(author -> new GetAuthorsResponseModel(author.getId(), author.getFullName(), author.getAbout(), author.getBirthDate(), author.getDeathDate())).toList();
        return new SuccessDataResponse<>("döndü", getAuthorsResponse);
    }

    private void checkIfAuthorAlreadyExist(Author author) {
        var optionalAuthor = authorRepository.findByFirstNameAndLastNameAndBirthDate(author.getFirstName(), author.getLastName(), author.getBirthDate());
        if (optionalAuthor.isPresent())
            throw new RuntimeException("author zaten var");
    }
}
