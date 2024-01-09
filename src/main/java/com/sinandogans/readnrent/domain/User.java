package com.sinandogans.readnrent.domain;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

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
    private String email;
    private String username;
    private String firstName;
    private String lastName;
    private byte[] passwordSalt;
    private byte[] passwordHash;
    @ManyToMany(mappedBy = "users")
    private List<UserRole> roles;

    public List<String> getRoles() {
        return roles.stream().map(roles -> roles.getRole()).toList();
    }
}
