using System.Collections.Generic;
using System.Text;

namespace Syphon
{
    internal static class Corrector
    {
        public static string Correct(string text)
        {
            var sb = new StringBuilder(text);
            foreach (var key in Rules.Keys)
            {
                sb.Replace(key, Rules[key]);
            }

            return sb.ToString();
        }

        private static readonly Dictionary<string, string> Rules =
            new Dictionary<string, string>
            {
                {",,", ","},
                {", ,", ","},
                {",-", "-"},
                {", -", "-"},
                {"- -", "-"},
                {" ,", ","},
                {",.", "."},
                {".,", ","},
                {",?", "?"},
                {", ?", "?"},
                {", !", "!"},
            };
    }
}