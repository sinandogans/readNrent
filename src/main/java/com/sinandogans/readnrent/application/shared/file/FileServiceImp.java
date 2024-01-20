package com.sinandogans.readnrent.application.shared.file;

import org.apache.tomcat.util.codec.binary.Base64;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;

@Service
public class FileServiceImp implements FileService {
    public static String basePath = "/Users/sinandogans/yazilim/angular/readNrentUI/src/assets/images/";

    @Override
    public String createAndSaveFile(String encodedFile, String path, String fileName) {
        String dbSavePath;
        try {
            byte[] fileBytes = Base64.decodeBase64(encodedFile);
            String filePath = basePath + path + fileName + ".png";
            Path fullPath = Path.of(filePath);
            Files.write(fullPath, fileBytes, StandardOpenOption.CREATE);
            dbSavePath = filePath.substring(filePath.indexOf("assets"));
        } catch (IOException e) {
            throw new RuntimeException("file operation error: " + e.getMessage());
        }
        return dbSavePath;
    }
}
