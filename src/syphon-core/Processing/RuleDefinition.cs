using Syphon.Parsing;

namespace Syphon.Processing
{
    internal sealed class RuleDefinition
    {
        public bool IgnoreWhitespaces { get; set; }

        public bool KillPreviousWhitespace { get; set; }

        public bool RequiresAi { get; set; }

        public int Propability { get; set; }

        public string[] SpecificWords { get; set; } = new string[] { };

        public string[] Templates { get; set; } = new string[] { };

        public TokenType AcceptType { get; set; }

        public TokenType[] Before { get; set; } = new TokenType[] { };

        public TokenType[] NotBefore { get; set; } = new TokenType[] { };

        public TokenType[] After { get; set; } = new TokenType[] { };

        public TokenType[] NotAfter { get; set; } =new TokenType[] { };
    }
}