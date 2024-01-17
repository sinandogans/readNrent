package com.sinandogans.readnrent.application.shared.file;

import org.apache.tomcat.util.codec.binary.Base64;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;

@Service
public class FileServiceImp implements FileService {
    public static String basePath = "/Users/sinandogans/yazilim/java/spring-projects/readNrent/images/";

    @Override
    public void createAndSaveFile(String encodedFile, String path, String fileName) {
        try {
            byte[] fileBytes = Base64.decodeBase64(encodedFile);
            String filePath = basePath + path + fileName + ".png";
            Path fullPath = Path.of(filePath);
            Files.write(fullPath, fileBytes, StandardOpenOption.CREATE);
        } catch (IOException e) {
            throw new RuntimeException("file operation error: " + e.getMessage());
        }
    }
}
