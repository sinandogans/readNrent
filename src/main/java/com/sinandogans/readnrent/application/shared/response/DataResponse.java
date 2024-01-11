package com.sinandogans.readnrent.application.shared.response;

import lombok.AllArgsConstructor;
import lombok.Getter;

@AllArgsConstructor
@Getter
public abstract class DataResponse<TData> implements IDataResponse<TData> {
    private boolean isSuccess;
    private String message;
    private TData data;
}
