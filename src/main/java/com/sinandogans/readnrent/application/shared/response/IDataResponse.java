package com.sinandogans.readnrent.application.shared.response;

public interface IDataResponse<TData> extends IResponse{
    TData getData();
}
