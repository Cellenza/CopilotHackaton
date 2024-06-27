#include "pch.h"
#include "Blacklist.h"
#include "SearchInDictionary.h"

bool SearchInDictionary::Execute(const std::map<std::string, int>& dimensions, int valueToFind)
{
    for (const auto& [key, value] : dimensions)
    {
        if (value == valueToFind)
        {
            return VerifyIpAddress(key);
        }
    }

    return false;
}

bool SearchInDictionary::VerifyIpAddress(std::string_view key)
{
    if ((std::count(key.begin(), key.end(), '.') == 3) && (Blacklist::IsWhiteList(key) || !Blacklist::IsBlacklisted(key)))
    {
        return true;
    }
    else if (std::count(key.begin(), key.end(), ':') == 7)
    {
        return true;
    }
     
    return false;
}

bool SearchInDictionary::VerifyIpAddressSimple(std::string_view key)
{
    if (std::count(key.begin(), key.end(), '.') == 3)
    {
        return true;
    }
    else if (std::count(key.begin(), key.end(), ':') == 7)
    {
        return true;
    }

    return false;
}