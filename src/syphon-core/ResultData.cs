using System;
using System.Collections.Generic;
using Syphon.Parsing;

namespace Syphon
{
    public sealed class ResultData
    {
        private readonly IList<Token> _tokens;
        private readonly Lazy<string> _plainText;
        private readonly Lazy<string> _html;

        internal ResultData(IList<Token> tokens, int possibleChanges, int performedChanges)
        {
            _tokens = tokens;
            PossibleChanges = possibleChanges;
            PerformedChanges = performedChanges;
            _plainText = new Lazy<string>(RenderPlainText);
            _html = new Lazy<string>(RenderHtml);
        }

        public int PossibleChanges { get; }
        public int PerformedChanges { get; }
        public TimeSpan Time { get; internal set; }

        public string PlainText => _plainText.Value;
        public string Html => _html.Value;
        
        public void Render(IResultRenderer renderer)
        {
            foreach (var token in _tokens)
            {
                if (token.Changed)
                {
                    renderer.AppendChanged(token.Text);
                }
                else
                {
                    renderer.AppendUnchanged(token.Text);
                }
            }
            renderer.End();
        }

        private string RenderPlainText()
        {
            var renderer = new PlainTextResultRenderer();
            Render(renderer);

            return renderer.Result;
        }

        private string RenderHtml()
        {
            var renderer = new HtmlResultRenderer();
            Render(renderer);

            return renderer.Result;
        }
    }
}
