using System.Collections.Generic;
using System.Threading.Tasks;
using Syphon.Parsing;

namespace Syphon.Processing
{
    internal sealed class TextProcessor
    {
        public TextProcessor(IEnumerable<IRule> rules, IWordBuilder generator)
        {
            this.rules = rules;
            builder = generator;
        }

        public int Level { get; set; }

        public IList<Token> Process(IEnumerable<Token> tokens, bool aiEnabled)
        {
            var listTokens = new List<Token>(tokens);

            Words = 0;
            foreach (var rule in rules)
            {
                Words += rule.GetTemplateCount();
            }

            Parallel.ForEach(
                rules,
                rule =>
                {
                    rule.Level = Level;
                    rule.OnPerformed += (s, e) => { lock (this) PerformedChanges++; };
                    rule.OnPossible += (s, e) => { lock (this) PossibleChanges++; };
                    rule.Builder = builder;

                    for (var i = 0; i < listTokens.Count; i++)
                    {
                        if (listTokens[i].Changed)
                            continue;

                        if (rule.Match(listTokens, i, aiEnabled))
                        {
                            listTokens[i] = rule.Process(listTokens, i);
                        }
                    }
                });

            return listTokens;
        }

        public int PossibleChanges { get; private set; }
        public int PerformedChanges { get; private set; }
        public int Words { get; private set; }

        private readonly IWordBuilder builder;
        private readonly IEnumerable<IRule> rules;
    }
}