using Syphon.Parsing;
using Syphon.Processing;
    
namespace Syphon.Configuration
{
    internal sealed class FaggotRuPreset : IPreset
    {
        public string Id => "faggot-ru";

        public string Name => "Фрезеровщик нетрадиционной сексуальной ориентации Иван Дулин";

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
                "(?<end>(ил|ал|ась|ала|ало|али)\\b)", 
                "(?<end>(ат|или|ут|ыл|ыло|ыли|ыла)\\b)", 
                "(?<end>(ать|ить|еть|аться|еться|иться|ул|ил|ал|ула|ала|ила|улся|ился|ался|илась|алась|иться|улась|ило|ало|уло|илось|алось|улось)\\b)", 
            }),
            new Noun(new string[] {
                "(?<end>(ант|ин|ец|да|ер|ка|ок|зь|акт|ис|ор|ик|та|ул|он|ид|ри|уй|инг)\\b)", 
                "(?<end>(ма|чи|ча|че|чь|ну|ын|ына|ыни|ыно|от|ня|ди|ги|ра)\\b)", 
            }),
            new Adjective(new string[] {
                "[^\\b](?<end>(ый|ий|ай|ое|ие|ого|его|их|им|ом|ой|ых|ую|ая|уя)\\b)", 
                "[^\\b](?<end>(ый|ий|ай|ей|ой|ее|его|ого|им|ая|ия|ыя|оя|ому|ыми|ими|ым)\\b)", 
                "[^\\b](?<end>(его|ые|ии|ие)\\b)", 
            }),
            new Preposition(new string[] {
                "(?<end>\\b(и|в|на|от|под|за|как|что|со|или|у|но|из|за|под|к|для|до|после|без|можно|же|по|)\\b)", 
            }),
        };


        public IRule[] Rules { get; } = new IRule[]
        {
            new DefaultRule(new RuleDefinition
            {
                AcceptType = TokenType.Whitespace,
                Propability = 128,
                IgnoreWhitespaces = true,
                KillPreviousWhitespace = true,
                RequiresAi = false,
                Templates = new string[] {
                    ", сладкая моя сперма, ",
                    ", ебать меня в анусик, ",
                    ", отсосать мой сладкий хуй, ",
                    ", ебать тебя в попку, ",
                    " ,трахать меня в анус, ",
                    ", дрочить мои эрогенные зоны, ",
                    ", всосать мои яйца, ",
                    ", засадить тебе в жопу, ",
                    ", вставить тебе хуй в анал, ",
                    ", это просто анальная мастурбация, ",
                    ", отавтофеллируйся, ",
                    ", высосать говно из жопы, ",
                    ", клизму мне в анус, ",
                    ", яйца мне в попку, ",
                    ", лизать голову моего хуя, ",
                    ", сглотнуть сладкую жидкость нах, ",
                    ", обстричь мои анальные волосы, ",
                    ", порвать твой анус, ",
                    ", заткнуть мне жопу, ",
                    ", расхуярить твою толстую кишку, ",
                    ", отъеберить твою попку, ",
                    " - и это сладостное долбоёбство - ",
                    " - трахнуть тебя нахуй - ",
                    " - скушай мои сраки - ",
                    " - иметь меня шваброй в жопу - ",
                    " - облизать мои шоколадные яйца - ",
                    " - вылизать твои соски - ",
                    " - вставить тебе хуй в попку - ",
                    " - отсосать хуй и сплюнуть просто - ",
                    " - срать мне на мошонку - ",
                    " - ебать мои яички - ",
                    " - и тут сжимаются мышцы моего анала - ",
                    " - и говно из жопы так и прёт - ",
                    " - анальная сладость нарастает - ",
                    " - кончи же мне в попку - ",
                    " - выеби же меня, самец - ",
                    " - ебать меня в анал - ",
                    " - а я люблю блядунов-шалунишек - ",
                    " - ебать тебя в анальное отверстие - ",
                    ", ебать мою анальную целку, ",
                    ", всадить тебе хуй по самый аппендикс, ",
                    ", блядством это является гейским, ",
                    ", пидарасье, ",
                    ", ебать мой анус, ",
                    ", сапоги мне в жопу, ",
                    ", вазелин мне на хуй, ",
                    ", ебать тебя в анал, ",
                    ", анальная моя сила, ",
                    ", кончать сука мне на соски, ",
                    ", обосраный мой пупочек, ",
                    ", отлизать мою голову хуя, ",
                    ", а вагину в пизду, ",
                    ", анусы рулят, ",
                    ", уебериться по самое немогу через попку, ",
                    ", сучьи кишечные внутренности, ",
                    ", обонанироваться можно, ",
                    ", уебериться до раздражения ануса, ",
                    ", анальная блядь, ",
                    ", ебаный в рот и в анал, ",
                    ", накакать на хуй и на соски, ",
                    ", охуеть вполне вероятно, ",
                    ", ебливый ты пидар, ",
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
                RequiresAi = false,
                Templates = new string[] {
                    " . В общем, сосни-ка мой хуй, сладкий!",
                    ". А ты такой пративный, сучка!",
                    ". А вообще, срал я на хуй тебе!",
                    ". К слову, пойду я опорожню анус перед еблей...",
                    ". Но это всё хуйня и не волнует пидаров!",
                    ". Блядь, но это уже анальный пиздец!",
                    ". Охуеннейше, обожаю анальный!",
                    ". Восхитительно в жопу мне вставили!",
                    ". Это типичное мнение пидарков.",
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
                RequiresAi = false,
                Templates = new string[] {
                    "? Ебать тебя спереди и сзади!",
                    "? Удовлетворить меня анально!",
                    "? Срал я на всю эту хуйню.",
                    "? Анально сложный вопрос...",
                    "? Пидорский вопрос...",
                    ", сука еберко?",
                    ", тупой мудак?",
                    ", педераст?",
                    ", анальное ебанько?",
                    "? Охуенно жопный вопрос.",
                    "? Пиздец, но вопрос для педерастов.",
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
            new DefaultRule(new RuleDefinition
            {
                AcceptType = TokenType.Whitespace,
                Propability = 128,
                IgnoreWhitespaces = true,
                KillPreviousWhitespace = true,
                RequiresAi = true,
                Templates = new string[] {
                    ", ебать меня в {noun:Accusative}, ",
                    ", отсосать мой сладкий {noun}, ",
                    ", ебать тебя в {noun:Accusative}, ",
                    " ,трахать меня в {noun:Accusative}, ",
                    ", вставить тебе {noun:Accusative} в анал, ",
                    ", это просто анальный {noun}, ",
                    ", высосать говно из {noun:Genitive}, ",
                    ", клизму мне в {noun:Accusative}, ",
                    ", яйца мне в попку, ",
                    ", лизать голову моего {noun:Genitive}, ",
                    " - иметь меня {noun:Ablative} в жопу - ",
                    " - вставить тебе {noun:Accusative} в попку - ",
                    " - отсосать {noun:Accusative} - ",
                    " - срать мне на {noun:Accusative} - ",
                    " - кончи же мне в {noun:Accusative} - ",
                    " - выеби же меня, {noun} - ",
                    " - ебать меня в {noun:Accusative} - ",
                    ", всадить тебе {noun:Accusative} по самый {noun}, ",
                    ", ебать мой {noun}, ",
                    ", сапоги мне в {noun:Accusative}, ",
                    ", ебать тебя в {noun:Accusative}, ",
                    ", отлизать мою голову {noun:Genitive}, ",
                    ", уебериться по самое немогу через {noun:Accusative}, ",
                    ", уебериться до раздражения {noun:Genitive}, ",
                    ", анальный {noun}, ",
                    ", накакать на {noun:Accusative} и на {noun:Accusative}, ",
                    ", ебливый ты {noun}, ",
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
                    " . В общем, сосни-ка мой {noun}, сладкий!",
                    ". А ты такой противный, {noun}!",
                    ". А вообще, срал я на {noun:Accusative} тебе!",
                    ". Блядь, но это уже анальный {noun(2)}!",
                    ". Восхитительно в {noun:Accusative} мне вставили!",
                    ". Это типичное мнение {noun:Genitive}.",
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
                    "? Срал я на все это {noun:Accusative}.",
                    ", {noun(1)}, {noun(1)}?",
                    ", тупой {noun(1)}?",
                    ", {noun(1)}?",
                    ", анальный {noun(1)}?",
                    "? Пиздец, но вопрос для {noun:Genitive}.",
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
                ("асик", Cases.Nominative),
                ("аник", Cases.Nominative),
                ("осик", Cases.Nominative),
                ("охуй", Cases.Nominative),
                ("асика", Cases.Genitive),
                ("аника", Cases.Genitive),
                ("осика", Cases.Genitive),
                ("охуя", Cases.Genitive),
                ("асику", Cases.Dative),
                ("анику", Cases.Dative),
                ("осику", Cases.Dative),
                ("охую", Cases.Dative),
                ("асика", Cases.Accusative),
                ("аника", Cases.Accusative),
                ("осика", Cases.Accusative),
                ("охуя", Cases.Accusative),
                ("асиком", Cases.Ablative),
                ("аником", Cases.Ablative),
                ("осиком", Cases.Ablative),
                ("охуем", Cases.Ablative),
                ("асике", Cases.Prepositional),
                ("анике", Cases.Prepositional),
                ("осике", Cases.Prepositional),
                ("охуе", Cases.Prepositional),
            });

    }
}
    
