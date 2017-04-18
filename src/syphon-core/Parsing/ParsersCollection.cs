using System.Collections.Generic;

namespace Syphon.Parsing
{
    internal sealed class ParsersCollection
    {
        public ParsersCollection(IEnumerable<IParser> parsers)
        {
            Parsers = parsers;
        }

        public IEnumerable<IParser> Parsers { get; private set; }

        public Token Match(string text, Token previous)
        {
            foreach (var parser in Parsers)
            {
                var token = parser.TryCreateToken(text, previous);
                if (token != null)
                    return token;
            }

            return Token.Unknown(text);
        }
    }
}