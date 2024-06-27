using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMethod
{
    public static class Blacklist
    {
        private static List<string> blackListedIP =
        [
            "12.5.6.7",
            "192.0.5.1"
        ];

        public static string GetCurrentIpAddress()
        {
            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);

            // Get the IP from GetHostByName method of dns class.
            return Dns.GetHostEntry(hostName).AddressList[0].ToString();
        }

        internal static bool IsBlacklisted(string key)
        {
            return blackListedIP.Contains(key);
        }

        internal static bool IsWhiteList(string key)
        {
            return key == GetCurrentIpAddress();
        }
    }
}