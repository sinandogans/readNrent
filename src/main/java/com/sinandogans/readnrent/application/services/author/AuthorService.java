package com.sinandogans.readnrent.application.services.author;

import com.sinandogans.readnrent.domain.book.Author;

import java.util.List;

public interface AuthorService {
    Author getById(Long id);

    List<Author> getByIds(List<Long> ids);
}
