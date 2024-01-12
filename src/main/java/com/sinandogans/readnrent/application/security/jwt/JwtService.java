package com.sinandogans.readnrent.application.security.jwt;

import com.sinandogans.readnrent.domain.user.User;
import io.jsonwebtoken.Claims;
import jakarta.servlet.http.HttpServletRequest;

import java.util.List;

public interface JwtService {
    String createToken(User user);
    String getEmail();
    boolean validateClaims();
    Claims resolveClaims();
    String resolveToken();
    List<String> getUserRoles();
    String getUserEmailFromJwtToken();
}
