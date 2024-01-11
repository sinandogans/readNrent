package com.sinandogans.readnrent.application.services.author;

import com.sinandogans.readnrent.application.repositories.AuthorRepository;
import com.sinandogans.readnrent.application.services.author.add.AddAuthorRequest;
import com.sinandogans.readnrent.application.services.author.update.UpdateAuthorRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.application.shared.response.SuccessResponse;
import com.sinandogans.readnrent.domain.book.Author;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AuthorServiceImp implements AuthorService {
    private final AuthorRepository authorRepository;
    private final ModelMapper modelMapper;

    public AuthorServiceImp(AuthorRepository authorRepository, ModelMapper modelMapper) {
        this.authorRepository = authorRepository;
        this.modelMapper = modelMapper;
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

    private void checkIfAuthorAlreadyExist(Author author) {
        var optionalAuthor = authorRepository.findByFirstNameAndLastNameAndBirthDate(author.getFirstName(), author.getLastName(), author.getBirthDate());
        if (optionalAuthor.isPresent())
            throw new RuntimeException("author zaten var");
    }
}
