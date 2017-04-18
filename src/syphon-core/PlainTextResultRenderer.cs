using System.Text;

namespace Syphon
{
    internal sealed class PlainTextResultRenderer : IResultRenderer
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public string Result => _builder.ToString();

        public void AppendUnchanged(string str)
        {
            _builder.Append(str);
        }

        public void AppendChanged(string str)
        {
            _builder.Append(str);
        }

        public void End() { }
    }
}