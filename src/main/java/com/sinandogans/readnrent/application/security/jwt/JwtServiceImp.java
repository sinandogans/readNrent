package com.sinandogans.readnrent.application.security.jwt;

import com.sinandogans.readnrent.domain.User;
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

    private final String TOKEN_HEADER = "Authorization";
    private final String TOKEN_PREFIX = "Bearer ";

    public JwtServiceImp() {
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

    public Claims resolveClaims(HttpServletRequest req) {
        try {
            String token = resolveToken(req);
            if (token != null) {
                return parseJwtClaims(token);
            }
            return null;
        } catch (ExpiredJwtException ex) {
            req.setAttribute("expired", ex.getMessage());
            throw ex;
        } catch (Exception ex) {
            req.setAttribute("invalid", ex.getMessage());
            throw ex;
        }
    }

    public String resolveToken(HttpServletRequest request) {

        String bearerToken = request.getHeader(TOKEN_HEADER);
        if (bearerToken != null && bearerToken.startsWith(TOKEN_PREFIX)) {
            return bearerToken.substring(TOKEN_PREFIX.length());
        }
        return null;
    }

    public boolean validateClaims(HttpServletRequest req) {
        try {
            return resolveClaims(req).getExpiration().after(new Date());
        } catch (Exception e) {
            throw e;
        }
    }

    public String getEmail(HttpServletRequest req) {
        return resolveClaims(req).getSubject();
    }

    public List<String> getUserRoles(HttpServletRequest req) {
        var claims = resolveClaims(req);
        return (List<String>) claims.get("userRoles");
    }

    private List<String> getRoles(Claims claims) {
        return (List<String>) claims.get("roles");
    }
}

