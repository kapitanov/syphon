using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Syphon.Parsing
{
    internal abstract class BaseWords : IParser
    {
        private readonly IEnumerable<Regex> _regexes;

        protected BaseWords(string[] rules)
        {
            _regexes = rules.Select(rule => new Regex(rule, RegexOptions.IgnoreCase)).ToList();
        }
        
        public Token TryCreateToken(string text, Token previous)
        {
            foreach (var regex in _regexes)
            {
                var match = regex.Match(text);
                if (match.Success)
                {
                    return CreateToken(text, match.Groups["end"].Value);
                }
            }

            return null;
        }

        protected abstract Token CreateToken(string text, string ending);       
    }
}