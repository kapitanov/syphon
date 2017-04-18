using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Syphon.Configuration;

namespace Syphon.Parsing
{
    internal sealed class TextParser
    {
        public TextParser(ParsersCollection parsers, IPreset preset)
        {
            this.parsers = parsers;

            var sb = new StringBuilder();
            sb.Append("(");
            for (var i = 0; i < preset.Boundaries.Length; i++)
            {
                foreach (var c in preset.Boundaries[i])
                {
                    sb.AppendFormat(@"\u{0:X4}", Convert.ToInt32(c));
                }

                if (i < preset.Boundaries.Length - 1)
                    sb.Append("|");
            }
            sb.Append(")");
            var pattern = sb.ToString();
            split = new Regex(pattern);
        }

        private readonly ParsersCollection parsers;

        private readonly Regex split;

        public IEnumerable<Token> Tokenize(string text)
        {
            var tokens = new List<Token>();
            var lastIndex = 0;
            foreach (Match match in split.Matches(text))
            {
                var str = text.Substring(lastIndex, match.Index - lastIndex);
                if (!string.IsNullOrEmpty(str))
                    tokens.Add(parsers.Match(str, tokens.Count > 0 ? tokens[0] : null));

                if (!string.IsNullOrEmpty(match.Value))
                    tokens.Add(parsers.Match(match.Value, tokens.Count > 0 ? tokens[0] : null));
                lastIndex = match.Index + match.Length;
            }
            return tokens;
        }
    }
}