package com.sinandogans.readnrent.application.services.library;

import com.sinandogans.readnrent.application.services.library.readinggoal.AddReadingGoalRequest;
import com.sinandogans.readnrent.application.services.library.readinggoal.UpdateReadingGoalRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.AddUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.UpdateUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.responses.GetUserBooksResponse;
import com.sinandogans.readnrent.application.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.shared.response.IResponse;

import java.util.List;

public interface LibraryService {
    IResponse addReadingGoal(AddReadingGoalRequest addReadingGoalRequest);

    IResponse updateReadingGoal(UpdateReadingGoalRequest updateReadingGoalRequest);

    IResponse deleteReadingGoal();

    IResponse addUserBook(AddUserBookRequest addUserBookRequest);

    IResponse updateUserBook(UpdateUserBookRequest updateUserBookRequest);

    IResponse deleteUserBook(Long id);

    IDataResponse<List<GetUserBooksResponse>> getUserBooks();
}
