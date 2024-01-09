package com.sinandogans.readnrent.application.aspects;

import com.sinandogans.readnrent.application.aspects.annotations.RolesAllowed;
import com.sinandogans.readnrent.application.security.jwt.JwtService;
import jakarta.servlet.http.HttpServletRequest;
import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Before;
import org.aspectj.lang.reflect.MethodSignature;
import org.springframework.context.annotation.Configuration;

import java.util.Arrays;
import java.util.HashMap;

@Configuration
@Aspect
public class AuthorizationAspect {
    private HttpServletRequest request;
    private final JwtService jwtService;

    public AuthorizationAspect(HttpServletRequest request, JwtService jwtService) {
        this.request = request;
        this.jwtService = jwtService;
    }

    @Before("@annotation(com.sinandogans.readnrent.application.aspects.annotations.RolesAllowed)")
    void authorize(JoinPoint joinPoint) {
        boolean isAuthorized = false;
        MethodSignature ms = (MethodSignature) joinPoint.getSignature();
        String[] expectedRoles = ms.getMethod().getAnnotation(RolesAllowed.class).values();
        HashMap<String, Boolean> expectedRolesMap = new HashMap<>();
        var expectedRolesList = Arrays.stream(expectedRoles).toList();

        for (String expectedRole : expectedRolesList)
            expectedRolesMap.put(expectedRole, true);

        var userRoles = jwtService.getUserRoles(request);
        for (String userRole : userRoles)
            if (expectedRolesMap.containsKey(userRole))
                isAuthorized = true;

        if (!isAuthorized)
            throw new RuntimeException("Sizi disari alalim.");
    }
}
