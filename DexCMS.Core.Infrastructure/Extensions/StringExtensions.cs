using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DexCMS.Core.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Changes spaces to an underscore and removes any characters that are not 0-9, a-z, A-Z, - or _.
        /// </summary>
        /// <param name="s">The string to be cleaned</param>
        /// <returns>A cleaned string with no special characters.</returns>
        public static string Clean(this string s)
        {

            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')
                    || c == '-' || c == '_')
                {
                    sb.Append(c);
                }
                else if (c == ' ')
                {
                    sb.Append('_');
                }
            }
            return sb.ToString();
        }

        public static string CapitalLetters(this string str)
        {
            return str.Transform(c => Char.IsUpper(c) ? c.ToString(CultureInfo.InvariantCulture) : null);
        }

        public static string Transform(this String src, Func<Char, string> transformation)
        {
            if (string.IsNullOrWhiteSpace(src))
            {
                return src;
            }

            var result = src.Select(transformation).Where(res => res != null).ToList();

            return string.Join("", result);
        }
    }
}
