package com.sinandogans.readnrent.application.services.author.update;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;
import java.util.List;

@Getter
@AllArgsConstructor
@Setter
public class UpdateAuthorRequest {
    private Long id;
    private String firstName;
    private String lastName;
    private String about;
    private LocalDate birthDate;
    private LocalDate deathDate;
}
