using System.Text;
using Syphon;

namespace syphon_telegram
{
    internal sealed class BotHtmlResultRenderer : IResultRenderer
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public string Result => _builder.ToString().Replace("\n", "<br />");

        public void AppendUnchanged(string str)
        {
            _builder.Append(str);
        }

        public void AppendChanged(string str)
        {
            _builder.Append("<i>");
            _builder.Append(str);
            _builder.Append("</i>");
        }

        public void End() { }
    }
}