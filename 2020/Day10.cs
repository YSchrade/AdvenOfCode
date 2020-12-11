using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    internal class Day10 : IDay
    {
        private readonly string[] _lines;

        public Day10(string path)
        {
            _lines = File.ReadAllLines(path);
        }
        public long Solve1()
        {
            var numbers = _lines.Select(l => int.Parse(l)).ToList();
            numbers.Add(0);
            numbers.Sort();
            numbers.Add(numbers.Last() + 3);

            var ergs = new Dictionary<int, int>();

            for (var i = 1; i < numbers.Count; i++)
            {
                var diff = numbers[i] - numbers[i - 1];
                if (!ergs.TryGetValue(diff, out _))
                    ergs[diff] = 0;

                ergs[diff]++;
            }



            return ergs[1] * ergs[3];
        }

        public long Solve2()
        {
            var numbers = _lines.Select(l => int.Parse(l)).ToList();
            numbers.Add(0);
            numbers.Sort();
            numbers.Add(numbers.Last() + 3);
            var count = 0;

            var poss = new long[numbers.Last() +1];
            Array.Fill(poss, 0);
            poss[0] = 1;
            poss[1] = poss[0];
            poss[2] = poss[0] + poss[1];
            poss[3] = poss[0] + poss[1] + poss[3];


            foreach (var number in numbers.Skip(3))
                poss[number] = poss[number - 1] + poss[number - 2] + poss[number - 3];

            return poss.Last();
            
        }
    }
}
