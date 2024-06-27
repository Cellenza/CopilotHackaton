#include "pch.h"
#include "Blacklist.h"

/*static*/ 
std::vector<std::string> Blacklist::blackListedIP = { "12.5.6.7", "192.0.5.1" };

/*static*/
std::string Blacklist::GetCurrentIpAddress()
{
    return "10.5.0.14";
}

/*static*/
bool Blacklist::IsBlacklisted(std::string_view ip)
{
    return std::find(blackListedIP.begin(), blackListedIP.end(), ip) != blackListedIP.end();
}

/*static*/
bool Blacklist::IsWhiteList(std::string_view ip)
{
    return ip == GetCurrentIpAddress();
}