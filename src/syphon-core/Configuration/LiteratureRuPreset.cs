using Syphon.Parsing;
using Syphon.Processing;
    
namespace Syphon.Configuration
{
    internal sealed class LiteratureRuPreset : IPreset
    {
        public string Id => "literature-ru";

        public string Name => "Литературный мат";

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
                    ", промудоблядовщина, ",
                    ", отъеберенностное состояние, ",
                    ", охуерический восторг, ",
                    ", уеберенностность, ",
                    ", блядство чистой воды, ",
                    ", выебанность на сто процентов, ",
                    ", заеберская моя империя, ",
                    ", клавиатуру мне во влагалище, ",
                    ", лизать мои эрогенные зоны, ",
                    ", коллайдер мне в жопу, ",
                    ", будь мой анус неладен, ",
                    ", отдефлорировать Ваши отверстия, ",
                    ", зажать в тиски Ваши соски, ",
                    ", выебать ваши отверстия, ",
                    ", обхуяриться как следует алкоголем, ",
                    ", отъеберить сотню самок, ",
                    ", снять тысячу блядей, ",
                    ", поглотить меня пиздой, ",
                    ", блядун мой ненасытный, ",
                    ", взять в полость рта головку хуя, ",
                    ", изхуярить неверных, ",
                    ", перенаправить Вас в пизду, ",
                    ", отонанировать мой хуй, ",
                    ", отмастурбировать Ваше очко, ",
                    ", разъеберить всё до коллапса, ",
                    ", уебениться до потери кровеносного давления, ",
                    " - и это естественно долбоёбство - ",
                    " - отпиздить Вас нахуй - ",
                    " - ссать и срать фекалиями - ",
                    " - уеберская рифма хореем - ",
                    " - охуевшая нынче молодёжь - ",
                    " - криптологию Вам в анус - ",
                    " - ебал я непрерывное кольцо - ",
                    " - срал я на глобальное потепление - ",
                    " - не сдержаться и насрать - ",
                    " - ебать мои яички - ",
                    " - прошу прощения, хуета это - ",
                    " - наебаться отличным виски - ",
                    " - модульный мой пиздоратор - ",
                    " - дифференциальное ебать уравнение - ",
                    " - однополо выебанная особь - ",
                    " - ебать этих пчёл-хуегрызов - ",
                    " - а Вы тоже охуенный блядун - ",
                    " - ебать Вас в анальное отверстие - ",
                    ", ебать Вашу целку, ",
                    ", всадить вам хуй по самый желудок, ",
                    ", блядством это является, ",
                    ", как говорится, пидарасье, ",
                    ", ебать тысячу анусов, ",
                    ", охуеть возможно от этого, ",
                    ", ебанавтика, ",
                    ", ебать всё население в анал, ",
                    ", невъебическая сила, ",
                    ", ебать мою диссертацию, ",
                    ", обосраный пуловер, ",
                    ", ебучая вагина, ",
                    ", ебать Ваше вагинальное отверстие, ",
                    ", ебаная лошадка, ",
                    ", уеберить Вас по самое немогу, ",
                    ", сучьи внутренности, ",
                    ", обонанироваться можно, ",
                    ", уебериться, ",
                    ", блядь, ",
                    ", ебаный в рот и в анал, ",
                    ", накакать на хуй и в пизду, ",
                    ", охуеть вполне вероятно, ",
                    ", ебливый Вы наш, ",
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
                    ". В общем, отсосите-ка хуйку!",
                    ". Мудоёбщина, прошу прощения!",
                    ". И срать на всё бытие!",
                    ". К слову, пойду я опорожню анус...",
                    ". Но это бля всё хуйня, как сказал бы неприличный человек!",
                    ". Блядь, пиздец просто полнейший, Вы тоже так считаете?",
                    ". Охуеннейше!",
                    ". Препиздостно!",
                    ". Это типичная точка зрения пидорасов.",
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
                    "? Ебать Вас спереди и сзади!",
                    "? Удовлетворить Вас анально!",
                    "? Какал я на всю эту хуйню.",
                    "? Еберически сложный вопрос...",
                    "? Пидорски-риторический вопрос...",
                    ", еберко?",
                    ", мудак?",
                    ", педераст?",
                    ", ебанько?",
                    "? Охуенно сложнейший вопрос.",
                    "? Пиздец, но это вопрос нерешаем.",
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
                    ", {noun}, ",
                    ", охуерический {noun}, ",
                    ", {noun} чистой воды, ",
                    ", {noun} на сто процентов, ",
                    ", заеберский мой {noun}, ",
                    ", клавиатуру мне во {noun:Accusative}, ",
                    ", {noun} мне в жопу, ",
                    ", будь мой {noun} неладен, ",
                    ", обхуяриться как следует {noun:Ablative}, ",
                    ", поглотить меня {noun:Ablative}, ",
                    ", {noun} мой ненасытный, ",
                    ", взять в полость рта головку {noun:Genitive}, ",
                    ", перенаправить Вас в {noun:Accusative}, ",
                    ", отонанировать мой {noun}, ",
                    ", разъеберить всё до {noun:Genitive}, ",
                    " - ссать и срать {noun:Ablative} - ",
                    " - {noun} Вам в {noun:Accusative} - ",
                    " - ебал я непрерывный {noun} - ",
                    " - срал я на {noun:Accusative} - ",
                    " - модульный мой {noun} - ",
                    " - дифференциальный ебать {noun(2)} - ",
                    " - а Вы тоже охуенный {noun(1)} - ",
                    ", всадить вам {noun} по самый {noun}, ",
                    ", {noun:Ablative} это является, ",
                    ", как говорится, {noun(1)}, ",
                    ", ебать всё население в {noun:Accusative}, ",
                    ", обосраный {noun}, ",
                    ", {noun}, ",
                    ", ебаный в рот и в анал, ",
                    ", накакать на {noun:Accusative} и в {noun:Accusative}, ",
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
                    ". В общем, отсосите-ка {noun:Accusative}!",
                    ". И срать на всего {noun:Accusative}!",
                    ". К слову, пойду я опорожню {noun:Accusative}...",
                    ". Но это бля всё хуйня, как сказал бы {noun(1)}!",
                    ". Блядь, {noun(2)} просто полнейший, Вы тоже так считаете?",
                    ". Это типичная точка зрения {noun:Accusative}.",
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
                    "? Еберически сложный {noun}...",
                    "? Пидорски-риторический {noun}...",
                    ", {noun}?",
                    ", {noun(2)}?",
                    ", {noun(1)}?",
                    "? Охуенно сложнейший {noun}.",
                    "? Пиздец, но этот {noun} нерешаем.",
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
                ("асиус", Cases.Nominative),
                ("аниус", Cases.Nominative),
                ("осиус", Cases.Nominative),
                ("охуй", Cases.Nominative),
                ("асиуса", Cases.Genitive),
                ("аниуса", Cases.Genitive),
                ("осиуса", Cases.Genitive),
                ("охуя", Cases.Genitive),
                ("асиусу", Cases.Dative),
                ("аниусу", Cases.Dative),
                ("осиусу", Cases.Dative),
                ("охую", Cases.Dative),
                ("асиуса", Cases.Accusative),
                ("аниуса", Cases.Accusative),
                ("осиуса", Cases.Accusative),
                ("охуя", Cases.Accusative),
                ("асиусом", Cases.Ablative),
                ("аниусом", Cases.Ablative),
                ("осиусом", Cases.Ablative),
                ("охуем", Cases.Ablative),
                ("асиусе", Cases.Prepositional),
                ("аниусе", Cases.Prepositional),
                ("осиусе", Cases.Prepositional),
                ("охуе", Cases.Prepositional),
            });

    }
}
    
