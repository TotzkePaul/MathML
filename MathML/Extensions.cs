using System;
using System.Collections.Generic;
using System.Text;

namespace MathML
{
    public static class Extensions
    {
        public static string ExtractUserName(this string description)
        {
            var split = description?.Split(";");
            if(split ==null || split.Length < 1)
            {
                return string.Empty;
            }
            return description.Split(";")[0];
        }

        public static string ExtractOperationName(this string description)
        {
            var split = description?.Split(";");
            if (split == null || split.Length < 2)
            {
                return string.Empty;
            }
            return description.Split(";")[1];
        }
    }
}
