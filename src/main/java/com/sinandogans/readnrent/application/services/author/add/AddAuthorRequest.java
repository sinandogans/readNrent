package com.sinandogans.readnrent.application.services.author.add;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;
import java.util.List;

@Getter
@AllArgsConstructor
@Setter
public class AddAuthorRequest {
    private String firstName;
    private String lastName;
    private String about;
    private LocalDate birthDate;
    private LocalDate deathDate;
}
