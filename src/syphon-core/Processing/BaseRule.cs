using System;
using System.Collections.Generic;
using System.Linq;
using Syphon.Parsing;

namespace Syphon.Processing
{
    internal abstract class BaseRule : IRule
    {
        protected BaseRule(RuleDefinition definition)
        {
            Definition = definition;
            RequiresAi = definition.RequiresAi;
        }

        public int GetTemplateCount()
        {
            return Definition.Templates.Length;
        }

        public IWordBuilder Builder { get; set; }

        public event EventHandler OnPossible;

        public event EventHandler OnPerformed;

        public int Level { get; set; }

        public bool RequiresAi { get; }

        public bool Match(IList<Token> tokens, int index, bool aiEnabled)
        {
            var token = tokens[index];
            var prev = tokens.Previous(index);
            var next = tokens.Next(index);

            if (token.Type != Definition.AcceptType)
                return false;

            if (Definition.SpecificWords.Length > 0)
                if (!Definition.SpecificWords.Contains(token.Text))
                    return false;

            if (prev != null)
            {
                if (!ValidatePrevious(prev))
                    return false;

                //if (Definition.IgnoreWhitespaces)
                //{
                //    for (var i = index - 2; i >= 0; i--)
                //    {
                //        var t = tokens[i];
                //        if (t.Type == TokenType.Whitespace)
                //            continue;

                //        if (!ValidatePrevious(t))
                //            return false;
                //        break;
                //    }
                //}
            }
            else
            //if (Definition.NotAfter.Length > 0)
            //return false;

            if (next != null)
            {
                if (!ValidateNext(next))
                    return false;
            }
            else if (Definition.NotBefore.Length > 0)
                return false;

            if (OnPossible != null)
                OnPossible(this, null);

            if ((random.Next(0, 255) * Level > Definition.Propability * 10))
                return false;

            if (RequiresAi & !aiEnabled)
                return false;

            if (OnPerformed != null)
                OnPerformed(this, null);
            return true;
        }

        private bool ValidateNext(Token next)
        {
            if (Definition.Before.Length > 0)
                if (!Definition.Before.Contains(next.Type))
                    return false;

            if (Definition.NotBefore.Length > 0)
                if (Definition.NotBefore.Contains(next.Type))
                    return false;
            return true;
        }

        private bool ValidatePrevious(Token prev)
        {
            if (Definition.After.Length > 0)
                if (!Definition.After.Contains(prev.Type))
                    return false;

            if (Definition.NotAfter.Length > 0)
                if (Definition.NotAfter.Contains(prev.Type))
                    return false;
            return true;
        }

        public virtual Token Process(IList<Token> tokens, int index)
        {
            var token = tokens[index];
            if (Definition.KillPreviousWhitespace && index > 0)
            {
                var prev = tokens[index - 1];
                if (prev.Type == TokenType.Whitespace)
                    prev.Change(string.Empty);
            }
            var template = PickTemplate();
            return token.Change(token.ApplyTemplate(
                RequiresAi
                    ?
                    Builder.BuildUpTemplate(template)
                    :
                    template));
        }

        protected string PickTemplate()
        {
            var next = random.Next(0, Definition.Templates.Length - 1);
            return Definition.Templates[next];
        }

        protected RuleDefinition Definition { get; private set; }

        private readonly Random random = new Random();
    }
}