package com.sinandogans.readnrent.api;

import com.sinandogans.readnrent.application.repositories.UserRepository;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("users")
public class UserController {
    private final UserRepository userRepository;

    public UserController(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

//    @PostMapping(value = "registerStudent")
//    public String registerStudent(@RequestBody StudentRegisterRequest studentRegisterRequest, HttpServletRequest request) {
//        var student = studentFactory.create(studentRegisterRequest.getEmail(), studentRegisterRequest.getUsername(), studentRegisterRequest.getFirstName(), studentRegisterRequest.getLastName(), studentRegisterRequest.getStudentName(), studentRegisterRequest.getPassword());
//        String jwt = jwtService.createToken(student);
//        userRepository.save(student);
//        return jwt;
//    }

//    @PostMapping(value = "getStudents")
//    public List<Student> getStudents() {
//        var students = (List<Student>) userRepository.findAll();
//        return students;
//    }

//    @GetMapping(value = "getStudent")
//    //@RolesAllowed(values = {"admin", "editor"})
//    public Student getStudent() {
//        var student = (Student) userRepository.findById(1L).get();
//        return student;
//    }
//
//    @GetMapping(value = "jwt")
//    public String getJwt() {
//        var student = (Student) userRepository.findById(2L).get();
//        String jwt = jwtService.createToken(student);
//        return jwt;
//    }
//
//    @GetMapping(value = "getStudentByStudentName")
//    public Student getStudentByStudentName(@RequestParam String studentName) {
//        var student = (Student) userRepository.findByStudentName(studentName).get();
//        return student;
//    }
}
