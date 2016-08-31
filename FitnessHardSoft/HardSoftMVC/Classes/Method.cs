using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardSoftMVC.Classes
{
    public class Method
    {
        public string TruncateAtWord(string value, int length, string someText = "...")
        {
            if (value == null || value.Length < length || value.IndexOf(" ", length) == -1)
                return value;

            return value.Substring(0, value.IndexOf(" ", length)) + someText;
        }
    }
}