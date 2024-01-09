package com.sinandogans.readnrent.application.services.shared.response;

public class SuccessResponse extends Response {
    public SuccessResponse(String message) {
        super(true, message);
    }
}
