using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    internal class Day9 : IDay
    {
        private readonly string[] _lines;

        public Day9(string path)
        {
            _lines = File.ReadAllLines(path);
        }

        public long Solve1() 
        {
            var preamble = 25;

            var numbers = _lines.Select(l => long.Parse(l)).ToArray();
            for (var i = preamble; i < numbers.Length; i++)
            {
                var contains = false;
                var pref = numbers[(i-preamble)..i];
                foreach (var num in pref)
                {
                    foreach (var num2 in pref.Skip(1))
                    {
                        if (num + num2 == numbers[i])
                        {
                            contains = true;
                            break;
                        }
                        
                    }

                    if (contains)
                        break;
                }

                if (!contains)
                    return numbers[i];

                contains = false;
            }
            return -1;
        }


        public long Solve2() 
        {
            var numbers = _lines.Select(l => long.Parse(l)).ToArray();
            var selectedNum = Solve1();
            var index = Array.IndexOf(numbers, selectedNum);
            var searchNums = numbers[..index].Where(n => n < selectedNum).ToList();

            for (var i = 0; i < searchNums.Count; i++)
            {
                var count = searchNums[i];
                for (var j = i+1; j < searchNums.Count; j++)
                {
                    count += searchNums[j];

                    if (count == selectedNum)
                    {
                        var range = searchNums.GetRange(i, j - i);
                        var smallest = range.Min();
                        var biggest = range.Max();
                        return biggest + smallest;
                    }
                        

                    if (count > selectedNum)
                        break;
                }
            }

            return -1;
        }
    }
}
