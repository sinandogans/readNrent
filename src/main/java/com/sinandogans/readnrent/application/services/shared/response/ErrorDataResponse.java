package com.sinandogans.readnrent.application.services.shared.response;

public class ErrorDataResponse<TData> extends DataResponse<TData>{
    ErrorDataResponse(String message, TData data) {
        super(false, message,data);
    }
}
