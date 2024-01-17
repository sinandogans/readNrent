package com.sinandogans.readnrent.application.services.author.add;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
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
    private String photo;
}
