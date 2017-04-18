using Syphon.Parsing;
using Syphon.Processing;

namespace Syphon.Configuration
{
    internal interface IPreset
    {
        string Id { get; }
        string Name { get; }
        string[] Boundaries { get; }
        IParser[] Parsers { get; }
        IRule[] Rules { get; }
        IWordBuilder WordBuilder { get; }
    }
}
