package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.services.author.AuthorService;
import com.sinandogans.readnrent.application.services.author.add.AddAuthorRequest;
import com.sinandogans.readnrent.application.services.author.get.GetAuthorsResponseModel;
import com.sinandogans.readnrent.application.services.author.update.UpdateAuthorRequest;
import com.sinandogans.readnrent.application.services.book.category.GetCategoriesResponseModel;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import org.apache.tomcat.util.codec.binary.Base64;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;
import java.util.List;

@RestController
@RequestMapping("authors")
public class AuthorController {
    private final AuthorService authorService;

    public AuthorController(AuthorService authorService) {
        this.authorService = authorService;
    }

    @PostMapping(value = "add")
    public IResponse register(@RequestBody AddAuthorRequest addAuthorRequest) {
        return authorService.addAuthor(addAuthorRequest);
    }

    @PutMapping(value = "update")
    public IResponse register(@RequestBody UpdateAuthorRequest updateAuthorRequest) {
        return authorService.updateAuthor(updateAuthorRequest);
    }

    @DeleteMapping(value = "delete")
    public IResponse register(@RequestParam Long id) {
        return authorService.deleteAuthor(id);
    }

    @GetMapping(value = "get-all")
    public IDataResponse<List<GetAuthorsResponseModel>> getAll() {
        return authorService.getAll();
    }
}
