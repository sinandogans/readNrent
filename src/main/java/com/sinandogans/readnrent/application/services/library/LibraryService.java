package com.sinandogans.readnrent.application.services.library;

import com.sinandogans.readnrent.application.services.library.userbook.requests.AddUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.DeleteUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.requests.UpdateUserBookRequest;
import com.sinandogans.readnrent.application.services.library.userbook.responses.GetUserBooksResponse;
import com.sinandogans.readnrent.application.services.shared.response.IDataResponse;
import com.sinandogans.readnrent.application.services.shared.response.IResponse;
import com.sinandogans.readnrent.application.services.library.readinggoal.AddReadingGoalRequest;
import com.sinandogans.readnrent.application.services.library.readinggoal.UpdateReadingGoalRequest;

import java.util.List;

public interface LibraryService {
    IResponse addReadingGoal(AddReadingGoalRequest addReadingGoalRequest);

    IResponse updateReadingGoal(UpdateReadingGoalRequest updateReadingGoalRequest);

    IResponse deleteReadingGoal();

    IResponse addUserBook(AddUserBookRequest addUserBookRequest);

    IResponse updateUserBook(UpdateUserBookRequest updateUserBookRequest);

    IResponse deleteUserBook(DeleteUserBookRequest deleteUserBookRequest);

    IDataResponse<List<GetUserBooksResponse>> getUserBooks();
}
