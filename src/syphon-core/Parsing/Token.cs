using System.Diagnostics;

namespace Syphon.Parsing
{
    [DebuggerDisplay("Token {Type}: {Text} Changed = {Changed}")]
    internal class Token
    {
        #region Factory methods

        public static Token Whitespace()
        {
            return new Token(TokenType.Whitespace, " ");
        }

        public static Token Dot()
        {
            return new Token(TokenType.Dot, ".");
        }

        public static Token Comma()
        {
            return new Token(TokenType.Comma, ",");
        }

        public static Token Colon()
        {
            return new Token(TokenType.Colon, ":");
        }

        public static Token Dash()
        {
            return new Token(TokenType.Dash, "-");
        }

        public static Token Exclamation()
        {
            return new Token(TokenType.Exclamation, "!");
        }

        public static Token Question()
        {
            return new Token(TokenType.Question, "?");
        }

        public static Token Quote()
        {
            return new Token(TokenType.Quote, "\"");
        }

        public static Token OpeningBrace()
        {
            return new Token(TokenType.OpeningBrace, "(");
        }

        public static Token ClosingBrace()
        {
            return new Token(TokenType.ClosingBrace, ")");
        }

        public static Token Verb(string text, string ending)
        {
            return new Token(TokenType.Verb, text, ending);
        }

        public static Token Adjective(string text, string ending)
        {
            return new Token(TokenType.Adjective, text, ending);
        }

        public static Token Noun(string text, string ending)
        {
            return new Token(TokenType.Noun, text, ending);
        }

        public static Token Preposition(string text)
        {
            return new Token(TokenType.Preposition, text);
        }

        public static Token Unknown(string text)
        {
            return new Token(TokenType.Unknown, text);
        }

        #endregion

        #region Private constructor

        private Token(TokenType type, string text)
            : this(type, text, string.Empty)
        { }

        private Token(TokenType type, string text, string ending)
        {
            Type = type;
            Text = text;
            Ending = ending;
        }

        #endregion

        public TokenType Type { get; private set; }

        public string Text { get; private set; }

        public string Ending { get; private set; }

        public bool Changed { get; set; }

        public Token Change(string text)
        {
            lock (this)
            {
                Text = text;
                Changed = true;
                return this;
            }
        }
    }
}