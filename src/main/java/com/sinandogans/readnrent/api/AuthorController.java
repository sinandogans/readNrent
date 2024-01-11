package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.services.author.AuthorService;
import com.sinandogans.readnrent.application.services.author.add.AddAuthorRequest;
import com.sinandogans.readnrent.application.services.author.update.UpdateAuthorRequest;
import com.sinandogans.readnrent.application.services.book.BookService;
import com.sinandogans.readnrent.application.services.book.add.AddBookRequest;
import com.sinandogans.readnrent.application.services.book.update.UpdateBookRequest;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import org.springframework.web.bind.annotation.*;

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
}
