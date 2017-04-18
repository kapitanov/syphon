namespace Syphon.Parsing
{
    internal sealed class Noun : BaseWords
    {
        public Noun(string[] rules) : base(rules) { }

        protected override Token CreateToken(string text, string ending) => Token.Noun(text, ending);
    }
}