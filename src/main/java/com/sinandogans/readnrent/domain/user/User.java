package com.sinandogans.readnrent.domain.user;

import com.sinandogans.readnrent.domain.library.ReadingGoal;
import com.sinandogans.readnrent.domain.library.UserBook;
import jakarta.persistence.*;
import jakarta.validation.constraints.Email;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "users")
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Email(message = "email formati yanlis bro")
    private String email;
    private String username;
    private String firstName;
    private String lastName;
    private byte[] passwordSalt;
    private byte[] passwordHash;
    @ManyToMany(mappedBy = "users")
    private List<UserRole> roles = new ArrayList<>();
    @OneToMany(mappedBy = "user")
    private List<UserBook> userBooks = new ArrayList<>();

    @OneToMany(mappedBy = "user")
    private List<ReadingGoal> readingGoals = new ArrayList<>();

    public ReadingGoal getCurrentReadingGoal() {
        var readingGoalsList = readingGoals.stream().filter(readingGoal -> readingGoal.getYear() == LocalDate.now().getYear()).toList();
        if (readingGoalsList.isEmpty())
            throw new RuntimeException("bu yil reading goal yok");
        return readingGoalsList.get(0);
    }

    public String getFullName() {
        return firstName + " " + lastName;
    }

    public List<String> getRoles() {
        return roles.stream().map(roles -> roles.getRole()).toList();
    }
}
