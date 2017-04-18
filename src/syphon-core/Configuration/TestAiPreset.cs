using Syphon.Parsing;
using Syphon.Processing;
    
namespace Syphon.Configuration
{
    internal sealed class TestAiPreset : IPreset
    {
        public string Id => "test-ai";

        public string Name => "test";

        public string[] Boundaries { get; } = new[]
        {
            " ", 
            "\n    ", 
            ".", 
            ",", 
            "-", 
            "—", 
            ":", 
            "!", 
            "?", 
        };

        public IParser[] Parsers { get; } = new IParser[]
        {
            new Punctuation(new string[] {
            }),
            new Verb(new string[] {
                "(?<end>(do)\\b)", 
            }),
            new Noun(new string[] {
                "(?<end>(er|or)\\b)", 
            }),
            new Adjective(new string[] {
                "[^\\b](?<end>(ing)\\b)", 
            }),
            new Preposition(new string[] {
                "(?<end>\\b(in|or|not|no|for|and|but|of|at|near|under|with|without)\\b)", 
                "(?<end>\\b(to|if)\\b)", 
            }),
        };


        public IRule[] Rules { get; } = new IRule[]
        {
            new DefaultRule(new RuleDefinition
            {
                AcceptType = TokenType.Adjective,
                Propability = 64,
                IgnoreWhitespaces = false,
                KillPreviousWhitespace = false,
                RequiresAi = true,
                Templates = new string[] {
                    "* fuck~",
                },
                SpecificWords = new string[] {
                },
                Before = new TokenType[] {
                },
                NotBefore = new TokenType[] {
                },
                After = new TokenType[] {
                },
                NotAfter = new TokenType[] {
                },
            }),
            new DefaultRule(new RuleDefinition
            {
                AcceptType = TokenType.Whitespace,
                Propability = 128,
                IgnoreWhitespaces = true,
                KillPreviousWhitespace = true,
                RequiresAi = true,
                Templates = new string[] {
                    ", {noun}, ",
                },
                SpecificWords = new string[] {
                },
                Before = new TokenType[] {
                },
                NotBefore = new TokenType[] {
                    TokenType.Comma,
                    TokenType.Dot,
                    TokenType.Quote,
                    TokenType.Colon,
                    TokenType.Question,
                    TokenType.Exclamation,
                    TokenType.Dash,
                    TokenType.OpeningBrace,
                    TokenType.ClosingBrace,
                },
                After = new TokenType[] {
                    TokenType.Noun,
                    TokenType.Verb,
                    TokenType.Adjective,
                },
                NotAfter = new TokenType[] {
                },
            }),
            new DefaultRule(new RuleDefinition
            {
                AcceptType = TokenType.Dot,
                Propability = 64,
                IgnoreWhitespaces = false,
                KillPreviousWhitespace = false,
                RequiresAi = true,
                Templates = new string[] {
                    " . Иди-ка пососи мой {noun}!",
                    " . Я даже не слышал о таком {noun:Prepositional}, как ты!",
                    " . Иди-ка пососи мой {noun}!",
                },
                SpecificWords = new string[] {
                },
                Before = new TokenType[] {
                },
                NotBefore = new TokenType[] {
                    TokenType.Comma,
                    TokenType.Dot,
                    TokenType.Quote,
                    TokenType.Colon,
                    TokenType.Question,
                    TokenType.Exclamation,
                    TokenType.Dash,
                    TokenType.OpeningBrace,
                    TokenType.ClosingBrace,
                },
                After = new TokenType[] {
                },
                NotAfter = new TokenType[] {
                    TokenType.Comma,
                    TokenType.Dot,
                    TokenType.Quote,
                    TokenType.Colon,
                    TokenType.Question,
                    TokenType.Exclamation,
                    TokenType.Dash,
                    TokenType.OpeningBrace,
                    TokenType.ClosingBrace,
                },
            }),
            new DefaultRule(new RuleDefinition
            {
                AcceptType = TokenType.Question,
                Propability = 128,
                IgnoreWhitespaces = false,
                KillPreviousWhitespace = false,
                RequiresAi = true,
                Templates = new string[] {
                    "? Что это за {noun}?!",
                },
                SpecificWords = new string[] {
                },
                Before = new TokenType[] {
                },
                NotBefore = new TokenType[] {
                    TokenType.Comma,
                    TokenType.Dot,
                    TokenType.Quote,
                    TokenType.Colon,
                    TokenType.Question,
                    TokenType.Exclamation,
                    TokenType.Dash,
                    TokenType.OpeningBrace,
                    TokenType.ClosingBrace,
                },
                After = new TokenType[] {
                },
                NotAfter = new TokenType[] {
                    TokenType.Comma,
                    TokenType.Quote,
                    TokenType.Colon,
                    TokenType.Exclamation,
                    TokenType.Dash,
                    TokenType.OpeningBrace,
                    TokenType.ClosingBrace,
                },
            }),
        };


        public IWordBuilder WordBuilder { get; } = new WordBuilder(
            new string[]
            {
                "пидор",
                "муд",
                "хуе",
                "манд",
                "уеб",
                "зл",
                "пизд",
                "говн",
                "перд",
                "ослоеб",
                "говноеб",
                "еб",
                "жоп",
                "выеб",
            },
            new (string, Cases)[]
            {
                ("ас", Cases.Nominative),
                ("ан", Cases.Nominative),
                ("ос", Cases.Nominative),
                ("охуй", Cases.Nominative),
                ("аса", Cases.Genitive),
                ("ана", Cases.Genitive),
                ("оса", Cases.Genitive),
                ("охуя", Cases.Genitive),
                ("асу", Cases.Dative),
                ("ану", Cases.Dative),
                ("осу", Cases.Dative),
                ("охую", Cases.Dative),
                ("аса", Cases.Accusative),
                ("ана", Cases.Accusative),
                ("оса", Cases.Accusative),
                ("охуя", Cases.Accusative),
                ("асом", Cases.Ablative),
                ("аном", Cases.Ablative),
                ("осом", Cases.Ablative),
                ("охуем", Cases.Ablative),
                ("асе", Cases.Prepositional),
                ("ане", Cases.Prepositional),
                ("осе", Cases.Prepositional),
                ("охуе", Cases.Prepositional),
            });

    }
}
    
