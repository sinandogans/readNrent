package com.sinandogans.readnrent.application.services.shared.response;

public class ErrorResponse extends Response {
    ErrorResponse(String message) {
        super(false, message);
    }
}
