package com.training.app.ComplexMethod;

import java.net.InetAddress;
import java.net.UnknownHostException;
import java.util.ArrayList;
import java.util.List;

public class Blacklist {
    private static List<String> blackListedIP = new ArrayList<>();

    static {
        blackListedIP.add("12.5.6.7");
        blackListedIP.add("192.0.5.1");
    }

    public static String getCurrentIpAddress() throws UnknownHostException {
        InetAddress localhost = InetAddress.getLocalHost();
        return localhost.getHostAddress();
    }

    public static boolean isBlacklisted(String key) {
        return blackListedIP.contains(key);
    }

    public static boolean isWhiteList(String key) throws UnknownHostException {
        return key.equals(getCurrentIpAddress());
    }
}
