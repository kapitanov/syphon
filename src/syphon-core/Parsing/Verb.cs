namespace Syphon.Parsing
{
    internal sealed class Verb : BaseWords
    {
        public Verb(string[] rules) : base(rules) { }

        protected override Token CreateToken(string text, string ending) => Token.Verb(text, ending);
    }
}