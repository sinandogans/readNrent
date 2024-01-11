package com.sinandogans.readnrent.application.shared.response;

import lombok.AllArgsConstructor;
import lombok.Getter;

@AllArgsConstructor
@Getter
public abstract class Response implements IResponse{
    private boolean isSuccess;
    private String message;
}
