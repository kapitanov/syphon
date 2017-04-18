namespace Syphon.Parsing
{
    internal interface IParser
    {
        Token TryCreateToken(string text, Token previous);
    }
}