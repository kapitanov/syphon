namespace Syphon.Parsing
{
    internal enum TokenType
    {
        /// <summary>
        /// 
        /// </summary>
        Unknown,

        /// <summary>
        /// 
        /// </summary>
        Whitespace,

        /// <summary>
        /// 
        /// </summary>
        Preposition,

        /// <summary>
        /// Сущ.
        /// </summary>
        Noun,

        /// <summary>
        /// Прил.
        /// </summary>
        Adjective,

        /// <summary>
        /// 
        /// </summary>
        Verb,

        /// <summary>
        /// "
        /// </summary>
        Quote,

        /// <summary>
        /// .
        /// </summary>
        Dot,

        /// <summary>
        /// ,
        /// </summary>
        Comma,


        /// <summary>
        /// :
        /// </summary>
        Colon,

        /// <summary>
        /// ?
        /// </summary>
        Question,

        /// <summary>
        /// !
        /// </summary>
        Exclamation,

        /// <summary>
        /// -
        /// </summary>
        Dash,

        /// <summary>
        /// (
        /// </summary>
        OpeningBrace,

        /// <summary>
        /// )
        /// </summary>
        ClosingBrace,
    }
}