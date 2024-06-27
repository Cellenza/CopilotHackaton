#pragma once
#include <vector>
#include <string>

class Blacklist
{
public:
    static std::vector<std::string> blackListedIP;

    static std::string GetCurrentIpAddress();
    static bool IsBlacklisted(std::string_view ip);
    static bool IsWhiteList(std::string_view ip);
};

