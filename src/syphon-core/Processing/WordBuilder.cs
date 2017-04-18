using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Syphon.Processing
{
    internal sealed class WordBuilder : IWordBuilder
    {
        private static readonly Regex Match = new Regex(@"{(?<type>[^(}|:|\(]+)(|:(?<cmd>([^(}||\(])+))(|\((?<len>[0-9]+)\))}", RegexOptions.Compiled);

        private static readonly char[] Gls = { 'у', 'е', 'ы', 'а', 'о', 'э', 'я', 'и', 'ю' };

        private readonly string[] _nounParts;
        private readonly (string Ending, Cases Case)[] _nounEndings;

        private readonly Random _random = new Random();

        public WordBuilder(string[] nounParts, (string, Cases)[] nounEndings)
        {
            _nounParts = nounParts;
            _nounEndings = nounEndings;
        }

        public string BuildUpTemplate(string template)
        {
            var t = Match.Replace(
                template,
                m =>
                {
                    var type = m.Groups["type"].Value;
                    var command = m.Groups["cmd"].Value;
                    int length;
                    if (!int.TryParse(m.Groups["len"].Value, out length))
                        return GenerateWord(type, command, null);

                    return GenerateWord(type, command, length);
                });
            return t;
        }

        private string GenerateWord(string type, string command, int? length)
        {
            var len = length ?? new Random().Next(1, 7);

            switch (type)
            {
                case "noun":
                    return GenerateNoun(command, len);

                default:
                    return string.Empty;
            }
        }

        private string GenerateNoun(string command, int levels)
        {
            var cs = string.IsNullOrEmpty(command) ? Cases.Nominative : (Cases)Enum.Parse(typeof(Cases), command);
            var endings = _nounEndings.Where(ending => ending.Case == cs).ToList();

            var sb = new StringBuilder();
            var prev = -1;
            for (var i = 0; i < levels; i++)
            {
                int current;
                do
                {
                    current = _random.Next(0, _nounParts.Length);
                }
                while (current == prev);
                sb.Append(_nounParts[current]);
                if (i != levels - 1)
                {
                    var lastChar = sb[sb.Length - 1];
                    if (!Gls.Any(c => c == lastChar))
                        sb.Append("о");
                }
                prev = current;
            }

            sb.Append(endings[_random.Next(0, endings.Count)].Ending);

            return sb.ToString();
        }
    }
}
