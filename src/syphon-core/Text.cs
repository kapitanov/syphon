using Syphon.Parsing;

namespace Syphon
{
    internal static class Text
    {
        public static string ApplyTemplate(this Token token, string template)
        {
            var wordBody = token.Text.Substring(0, token.Text.Length - token.Ending.Length);

            return template
                .Replace("*", token.Text)
                .Replace("#", wordBody)
                .Replace("~", token.Ending.ToLower());
        }
    }
}