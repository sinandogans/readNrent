package com.sinandogans.readnrent.application.services.author;

import com.sinandogans.readnrent.application.services.author.add.AddAuthorRequest;
import com.sinandogans.readnrent.application.services.author.get.GetAuthorsResponseModel;
import com.sinandogans.readnrent.application.services.author.update.UpdateAuthorRequest;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import com.sinandogans.readnrent.domain.book.Author;

import java.util.List;

public interface AuthorService {
    Author getById(Long id);

    List<Author> getByIds(List<Long> ids);

    IResponse addAuthor(AddAuthorRequest addAuthorRequest);

    IResponse updateAuthor(UpdateAuthorRequest updateAuthorRequest);

    IResponse deleteAuthor(Long id);

    IDataResponse<List<GetAuthorsResponseModel>> getAll();
}
