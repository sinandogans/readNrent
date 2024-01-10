package com.sinandogans.readnrent.application.events.listeners;

import com.sinandogans.readnrent.application.events.userbook.UserBookAddedEvent;
import org.springframework.context.event.EventListener;
import org.springframework.stereotype.Component;

@Component
public class UserBookListener {
    @EventListener
    void handleUserBookAddedEvent(UserBookAddedEvent event) {
        // handle UserRemovedEvent ...
        //TODO eventi handle et booku güncelle falans bambaska oldu.
        System.out.println();
    }
}
