package com.sinandogans.readnrent.application.security.jwt;

import com.sinandogans.readnrent.domain.User;
import io.jsonwebtoken.Claims;
import jakarta.servlet.http.HttpServletRequest;

import java.util.List;

public interface JwtService {
    String createToken(User user);
    String getEmail(HttpServletRequest req);
    boolean validateClaims(HttpServletRequest req);
    Claims resolveClaims(HttpServletRequest req);
    String resolveToken(HttpServletRequest request);
    List<String> getUserRoles(HttpServletRequest req);
}
