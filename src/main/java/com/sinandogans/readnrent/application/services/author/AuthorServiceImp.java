package com.sinandogans.readnrent.application.services.author;

import com.sinandogans.readnrent.application.repositories.AuthorRepository;
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
}
