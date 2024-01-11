package com.sinandogans.readnrent.domain.book;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;
import java.util.List;
import java.util.Objects;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class Author {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String firstName;
    private String lastName;
    private String about;
    private LocalDate birthDate;
    private LocalDate deathDate;
    @ManyToMany(mappedBy = "authors")
    private List<Book> books;

    public String getFullName() {
        return firstName + " " + lastName;
    }

    public boolean isSameAuthor(Author author) {
        if (Objects.equals(this.getFullName(), author.getFullName()) && this.birthDate == author.birthDate)
            return true;
        return false;
    }
}
