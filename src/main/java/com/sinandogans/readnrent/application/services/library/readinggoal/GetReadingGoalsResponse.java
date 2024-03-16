package com.sinandogans.readnrent.application.services.library.readinggoal;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
public class GetReadingGoalsResponse {
    private int goal;
    private int yearReadCount;
    private int year;
}
