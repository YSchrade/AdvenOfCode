using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    internal class Day6 : IDay
    {
        private readonly string _file;

        public Day6(string path)
        {
            _file = File.ReadAllText(path);
        }


        public long Solve1()
        {
            var groups = _file.Split(Environment.NewLine + Environment.NewLine);
            return groups.Sum(g => g.Replace(Environment.NewLine, "").ToCharArray().Distinct().Count());
        }


        public long Solve2()
        {
            var groups = _file.Split(Environment.NewLine + Environment.NewLine);
            var intersections = 0;
            foreach (var group in groups)
            {
                var persons = group.Split(Environment.NewLine);
                var charslist = persons.Select(p => p.ToCharArray());

                intersections += charslist
                                    .Skip(1)
                                    .Aggregate(
                                            new HashSet<char>(charslist.First()),
                                            (h, e) => { h.IntersectWith(e); return h; }
                                    ).Count;


            }
            return intersections;
        }
    }
}
