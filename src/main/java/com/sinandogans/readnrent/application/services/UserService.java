package com.sinandogans.readnrent.application.services;

import com.sinandogans.readnrent.domain.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UsernameNotFoundException;

public interface UserService {
    UserDetails loadUserByUsername(String email) throws UsernameNotFoundException;
    User findByEmail(String email);
}
