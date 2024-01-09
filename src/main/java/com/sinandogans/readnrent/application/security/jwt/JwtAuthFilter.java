package com.sinandogans.readnrent.application.security.jwt;

import com.sinandogans.readnrent.application.security.config.NotAuthorizedRequests;
import com.sinandogans.readnrent.application.services.UserService;
import com.sinandogans.readnrent.domain.User;
import jakarta.servlet.FilterChain;
import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.web.authentication.WebAuthenticationDetailsSource;
import org.springframework.stereotype.Component;
import org.springframework.web.filter.OncePerRequestFilter;

import java.io.IOException;

@Component
public class JwtAuthFilter extends OncePerRequestFilter {

    private JwtService jwtService;
    private UserService userService;

    public JwtAuthFilter(JwtService jwtService, UserService userService) {
        this.jwtService = jwtService;
        this.userService = userService;
    }

    @Override
    protected void doFilterInternal(HttpServletRequest request, HttpServletResponse response, FilterChain filterChain) throws ServletException, IOException {
        String requestPath = request.getRequestURL().toString();
        boolean isAuthenticated = true;
        for (String url : NotAuthorizedRequests.urls) {
            if (requestPath.contains(url))
                isAuthenticated = false;
        }
        if (isAuthenticated) {
            String email = jwtService.getEmail(request);
            if (email != null && SecurityContextHolder.getContext().getAuthentication() == null) {
                User user = userService.findByEmail(email);
                if (jwtService.validateClaims(request)) {
                    UsernamePasswordAuthenticationToken authToken = new UsernamePasswordAuthenticationToken(user, null, null);
                    authToken.setDetails(new WebAuthenticationDetailsSource().buildDetails(request));
                    SecurityContextHolder.getContext().setAuthentication(authToken);
                }
            }
        }
        filterChain.doFilter(request, response);
    }
}
