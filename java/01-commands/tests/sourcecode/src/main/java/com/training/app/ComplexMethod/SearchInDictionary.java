package com.training.app.ComplexMethod;

import java.net.UnknownHostException;
import java.util.Collections;
import java.util.Dictionary;

public class SearchInDictionary {
    public boolean execute(Dictionary<String, Integer> dimensions, int valueToFind) {
        for (String key : Collections.list(dimensions.keys())) {
            if (dimensions.get(key) == valueToFind) {
                return verifyIpAddress(key);
            }
        }

        return false;
    }

    private boolean verifyIpAddress(String key) {
        try {
            if (key.split("\\.").length == 4 && 
                (Blacklist.isWhiteList(key) || 
                !Blacklist.isBlacklisted(key))) {
                return true;
            } else if (key.split(":").length == 8) {
                return true;
            }
        } catch (UnknownHostException e) {
            e.printStackTrace();
        }

        return false;
    }

    private boolean verifyIpAddressSimple(String key) {
        if (key.split("\\.").length == 4) {
            return true;
        } else if (key.split(":").length == 8) {
            return true;
        }

        return false;
    }
}
