package com.sinandogans.readnrent.application.services.shared.response;

public class SuccessDataResponse<TData> extends DataResponse<TData> {
    public SuccessDataResponse(String message, TData data) {
        super(true, message, data);
    }
}
