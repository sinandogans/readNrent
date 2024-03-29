package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.services.library.LibraryService;
import com.sinandogans.readnrent.application.services.library.readinggoal.AddReadingGoalRequest;
import com.sinandogans.readnrent.application.services.library.readinggoal.GetReadingGoalsResponse;
import com.sinandogans.readnrent.application.services.library.readinggoal.UpdateReadingGoalRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.AddUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.UpdateUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.responses.GetUserBooksResponse;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("library")
public class LibraryController {
    private final LibraryService libraryService;

    public LibraryController(LibraryService libraryService) {
        this.libraryService = libraryService;
    }

    @PostMapping(value = "add-reading-goal")
    public IResponse addReadingGoal(@RequestBody AddReadingGoalRequest addReadingGoalRequest) {
        return libraryService.addReadingGoal(addReadingGoalRequest);
    }

    @PutMapping(value = "update-reading-goal")
    public IResponse updateReadingGoal(@RequestBody UpdateReadingGoalRequest updateReadingGoalRequest) {
        return libraryService.updateReadingGoal(updateReadingGoalRequest);
    }

    @DeleteMapping(value = "delete-reading-goal")
    public IResponse updateReadingGoal() {
        return libraryService.deleteReadingGoal();
    }

    @PostMapping(value = "add-userbook")
    public IResponse addUserBook(@RequestBody AddUserBookRequest addUserBookRequest) {
        return libraryService.addUserBook(addUserBookRequest);
    }

    @PutMapping(value = "update-userbook")
    public IResponse updateUserBook(@RequestBody UpdateUserBookRequest updateUserBookRequest) {
        return libraryService.updateUserBook(updateUserBookRequest);
    }

    @DeleteMapping(value = "delete-userbook")
    public IResponse updateUserBook(@RequestParam Long id) {
        return libraryService.deleteUserBook(id);
    }

    @GetMapping(value = "get-userbooks")
    public IDataResponse<List<GetUserBooksResponse>> getUserBooks(@RequestParam String username) {
        return libraryService.getUserBooks(username);
    }

    @GetMapping(value = "get-reading-goals")
    public IDataResponse<List<GetReadingGoalsResponse>> getReadingGoals(@RequestParam String username) {
        return libraryService.getReadingGoals(username);
    }
}
