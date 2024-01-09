package com.sinandogans.readnrent.application.security.hashing;

public interface HashService {
    byte[] saltPassword(String password);
    byte[] hashPassword(String password, byte[] salt);
}
