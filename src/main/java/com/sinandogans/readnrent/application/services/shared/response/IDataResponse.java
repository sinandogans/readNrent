package com.sinandogans.readnrent.application.services.shared.response;

public interface IDataResponse<TData> extends IResponse{
    TData getData();
}
