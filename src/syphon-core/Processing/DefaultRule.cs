using System.Collections.Generic;
using Syphon.Parsing;

namespace Syphon.Processing
{
    internal sealed class DefaultRule : BaseRule
    {
        internal DefaultRule(RuleDefinition definition)
            : base(definition)
        { }
        
        public override Token Process(IList<Token> tokens, int index)
        {
            var template = PickTemplate();
            template = RequiresAi
                ?
                Builder.BuildUpTemplate(template)
                :
                template;
            return tokens[index].Change(tokens[index].ApplyTemplate(template));
        }
    }
}