using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GamePulse_Frm
{
    public static class clsUtil
    {
        public static bool IsValidDecimal(string value)
        {
            string pattern = @"^[0-9]+(\.[0-9]{1,2})?$";
            return Regex.IsMatch(value, pattern);
        }

        public static bool IsValidCardUID(string uid)
        {
            string pattern = @"^[a-zA-Z0-9]{5,20}$";
            return Regex.IsMatch(uid, pattern);
        }
    }
}
