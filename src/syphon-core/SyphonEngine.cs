using System.Diagnostics;
using Syphon.Configuration;
using Syphon.Parsing;
using Syphon.Processing;

namespace Syphon
{
    public sealed class SyphonEngine
    {
        private readonly IPreset _preset;
        private readonly Level _level;
        private readonly bool _enableAi;

        private readonly TextParser _parser;

        public SyphonEngine(
            Preset preset,
            Level level,
            bool enableAi)
        {
            _preset = PresetFactory.Create(preset);
            _level = level;
            _enableAi = enableAi;

            _parser = new TextParser(new ParsersCollection(_preset.Parsers), _preset);
        }

        public ResultData Process(string text, int times = 1)
        {
            var watch = Stopwatch.StartNew();
            var processor = new TextProcessor(_preset.Rules, _preset.WordBuilder) { Level = _level.Value };
            ResultData result = null;

            for (var i = 0; i < times; i++)
            {
                result = ProcessOnce(processor, text);
                text = result.PlainText;
            }

            watch.Stop();
            if (result != null)
            {
                result.Time = watch.Elapsed;

                return result;
            }

            return null;
        }

        private ResultData ProcessOnce(TextProcessor processor, string text)
        {
            text = Corrector.Correct(text);
            var tree = processor.Process(_parser.Tokenize(text), _enableAi);
            var result = new ResultData(tree, processor.PossibleChanges, processor.PerformedChanges);

            return result;
        }
    }
}