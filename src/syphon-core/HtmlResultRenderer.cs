using System.Text;

namespace Syphon
{
    internal sealed class HtmlResultRenderer : IResultRenderer
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public string Result => _builder.ToString().Replace("\n", "<br />");

        public void AppendUnchanged(string str)
        {
            _builder.Append(str);
        }

        public void AppendChanged(string str)
        {
            _builder.Append("<span class=\"marked\">");
            _builder.Append(str);
            _builder.Append("</span>");
        }

        public void End() { }
    }
}