package com.sinandogans.readnrent.application.shared.response;

public class ErrorResponse extends Response {
    public ErrorResponse(String message) {
        super(false, message);
    }
}
