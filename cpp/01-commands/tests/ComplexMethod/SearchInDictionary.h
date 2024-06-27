#pragma once
#include <map>
#include <string>

class SearchInDictionary
{
public:
    bool Execute(const std::map<std::string, int>& dimensions, int valueToFind);

private:
    bool VerifyIpAddress(std::string_view key);
    bool VerifyIpAddressSimple(std::string_view key);
};

