using System;
using System.Collections.Generic;
using Syphon.Parsing;

namespace Syphon.Processing
{
    internal interface IRule
    {
        int GetTemplateCount();
        event EventHandler OnPossible;
        event EventHandler OnPerformed;
        int Level { get; set; }
        IWordBuilder Builder { get; set; }
        bool Match(IList<Token> tokens, int index, bool aiEnabled);
        Token Process(IList<Token> tokens, int index);
    }
}