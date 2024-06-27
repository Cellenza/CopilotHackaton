namespace ComplexMethod
{
    internal class SearchInDictionary
    {
        public bool Execute(Dictionary<string, int> dimensions, int valueToFind)
        {
            foreach (var item in dimensions)
            {
                if (item.Value == valueToFind)
                {
                    return VerifyIpAddress(item.Key);
                }
            }

            return false;
        }

        private bool VerifyIpAddress(string key)
        {
            if (key.Split('.').Length == 4 && (Blacklist.IsWhiteList(key) || !Blacklist.IsBlacklisted(key)))
            {
                return true;
            }
            else if (key.Split(':').Length == 8)
            {
                return true;
            }

            return false;
        }

        private bool VerifyIpAddressSimple(string key)
        {
            if (key.Split('.').Length == 4)
            {
                return true;
            }
            else if (key.Split(':').Length == 8)
            {
                return true;
            }

            return false;
        }
    }
}