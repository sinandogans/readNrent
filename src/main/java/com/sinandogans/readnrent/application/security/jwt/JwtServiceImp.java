package com.sinandogans.readnrent.application.security.jwt;

import com.sinandogans.readnrent.domain.user.User;
import io.jsonwebtoken.*;
import jakarta.servlet.http.HttpServletRequest;
import org.springframework.stereotype.Service;

import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;

@Service
public class JwtServiceImp implements JwtService {

    //@Value("${READNRENT_SECRET_KEY}")
    private String SECRET = "supersecretkey123supersecretkey123supersecretkey123supersecretkey123supersecretkey123supersecretkey123supersecretkey123supersecretkey123supersecretkey123";
    private long accessTokenValidity = 60 * 60 * 1000;

    private final JwtParser jwtParser;
    private HttpServletRequest request;

    private final String TOKEN_HEADER = "Authorization";
    private final String TOKEN_PREFIX = "Bearer ";

    public JwtServiceImp(HttpServletRequest request) {
        this.request = request;
        this.jwtParser = Jwts.parser().setSigningKey(SECRET);
    }

    public String createToken(User user) {
        Claims claims = Jwts.claims().setSubject(user.getEmail());
        claims.put("firstName", user.getFirstName());
        claims.put("lastName", user.getLastName());
        claims.put("userRoles", user.getRoles());
        Date tokenCreateTime = new Date();
        Date tokenValidity = new Date(tokenCreateTime.getTime() + TimeUnit.MINUTES.toMillis(accessTokenValidity));
        return Jwts.builder()
                .setClaims(claims)
                .setExpiration(tokenValidity)
                .signWith(SignatureAlgorithm.HS512, SECRET)
                .compact();
    }

    private Claims parseJwtClaims(String token) {
        return jwtParser.parseClaimsJws(token).getBody();
    }

    public Claims resolveClaims() {
        try {
            String token = resolveToken();
            if (token != null) {
                return parseJwtClaims(token);
            }
            return null;
        } catch (ExpiredJwtException ex) {
            request.setAttribute("expired", ex.getMessage());
            throw ex;
        } catch (Exception ex) {
            request.setAttribute("invalid", ex.getMessage());
            throw ex;
        }
    }

    public String resolveToken() {

        String bearerToken = request.getHeader(TOKEN_HEADER);
        if (bearerToken != null && bearerToken.startsWith(TOKEN_PREFIX)) {
            return bearerToken.substring(TOKEN_PREFIX.length());
        }
        return null;
    }

    public boolean validateClaims() {
        try {
            return resolveClaims().getExpiration().after(new Date());
        } catch (Exception e) {
            throw e;
        }
    }

    public String getEmail() {
        return resolveClaims().getSubject();
    }

    public List<String> getUserRoles() {
        var claims = resolveClaims();
        return (List<String>) claims.get("userRoles");
    }

    public String getUserEmailFromJwtToken() {
        return getEmail();
    }

    private List<String> getRoles(Claims claims) {
        return (List<String>) claims.get("roles");
    }

}

