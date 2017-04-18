namespace Syphon.Parsing
{
    internal sealed class Preposition : BaseWords
    {
        public Preposition(string[] rules) : base(rules) { }

        protected override Token CreateToken(string text, string ending) => Token.Preposition(text);
    }
}