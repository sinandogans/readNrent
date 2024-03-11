package com.sinandogans.readnrent.application.services.book.book.get.getdetail;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Setter
@Getter
@NoArgsConstructor
@AllArgsConstructor
public class GetBookDetailStatisticsDTO {
    private int reviewCount;
    private int likes;
    private int views;
    private int readCount;
    private int readingCount;
    private int toBeReadCount;
}
