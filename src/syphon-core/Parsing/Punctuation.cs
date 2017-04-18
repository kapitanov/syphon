namespace Syphon.Parsing
{
    internal sealed class Punctuation : IParser
    {
        public Punctuation(string[] _) { }

        public Token TryCreateToken(string text, Token previous)
        {
            switch (text)
            {
                case " ":
                    return Token.Whitespace();

                case ".":
                    return Token.Dot();

                case ",":
                    return Token.Comma();

                case "-":
                    return Token.Dash();

                case "--":
                    return Token.Dash();

                case ":":
                    return Token.Colon();

                case "!":
                    return Token.Exclamation();

                case "?":
                    return Token.Question();

                case "\"":
                    return Token.Quote();

                case "(":
                    return Token.OpeningBrace();

                case ")":
                    return Token.ClosingBrace();

                default:
                    return null;
            }
        }
    }
}