using System;
using System.Collections.Generic;
using System.Linq;

namespace SendSlackMessage.Helpers
{
    static class SsmHelpers
    {
        internal static bool ValidateStrings(IEnumerable<string> strings)
        {
            if (strings == null || !strings.Any()) return false;
            foreach(string str in strings)
            {
                if (String.IsNullOrWhiteSpace(str))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
