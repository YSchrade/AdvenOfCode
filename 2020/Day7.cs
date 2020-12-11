using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    internal class Day7 : IDay
    {
        private readonly string[] _lines;
        private readonly Dictionary<string, List<string>> _graph1 = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, List<(string, int)>> _graph2 = new Dictionary<string, List<(string, int )>>();

        public Day7(string path)
        {
            _lines = File.ReadAllLines(path);
        }


        public long Solve1()
        {            
            foreach (var line in _lines)
            {
                var primColor = Regex.Match(line, @"(.+?) bags").Groups[1].Value;
                var insideColors = Regex.Matches(line, @"(\d+) (.+?) bag").Select(m => m.Groups[2].Value).ToList();

                _graph1.Add(primColor, insideColors);
            }

            return _graph1.Keys.Sum(k => ContainsGoldBag(k) ? 1 : 0) -1;
        }


        public long Solve2()
        {
            
            foreach (var line in _lines)
            {
                var primColor = Regex.Match(line, @"(.+?) bags").Groups[1].Value;
                var insideColors = Regex.Matches(line, @"(\d+) (.+?) bag")
                                    .Select(m => (m.Groups[2].Value, int.Parse(m.Groups[1].Value))).ToList();

                _graph2.Add(primColor, insideColors);
            }

            return CountInside("shiny gold") - 1;
        }

        private bool ContainsGoldBag(string color) 
            => color == "shiny gold" || _graph1[color].Any(c => ContainsGoldBag(c));

        private int CountInside(string color)
        {
            var erg = 0;
            
            foreach ((var name, var count) in _graph2[color])
                erg += count * CountInside(name);

            return erg + 1;
        }

    }
}
