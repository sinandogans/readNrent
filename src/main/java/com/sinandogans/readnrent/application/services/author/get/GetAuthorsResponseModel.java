package com.sinandogans.readnrent.application.services.author.get;

import lombok.AllArgsConstructor;
import lombok.Getter;

import java.time.LocalDate;

@Getter
@AllArgsConstructor
public class GetAuthorsResponseModel {
    private Long id;
    private String fullName;
    private String about;
    private LocalDate birthDate;
    private LocalDate deathDate;
}
