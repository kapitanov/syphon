namespace Syphon.Parsing
{
    internal sealed class Adjective : BaseWords
    {
        public Adjective(string[] rules) : base(rules) { }

        protected override Token CreateToken(string text, string ending) => Token.Adjective(text, ending);
    }
}