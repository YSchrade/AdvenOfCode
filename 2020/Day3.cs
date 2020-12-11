using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    internal class Day3 : IDay
    {
        private readonly List<string> _map;

        public Day3(string path)
        {
            _map = ReadMap(path);
        }



        public long Solve1() 
            => GetTreeCount(3, 1);

        public long Solve2() 
            => GetTreeCount(1, 1) * GetTreeCount(3, 1) * GetTreeCount(5, 1) * GetTreeCount(7, 1) * GetTreeCount(1, 2);


        private long GetTreeCount(int right, int down)
        {
            var mod = _map[0].Length;
            var count = 0;
            var posX = 0;
            for (var i = 0; i < _map.Count; i += down)
            {
                if (_map[i][posX] == '#')
                    count++;
                posX = (posX + right) % mod;
            }

            return count;
        }

        private List<string> ReadMap(string mapPath)
        {
            var map = new List<string>();
            using var reader = new StreamReader(File.OpenRead(mapPath));

            while (!reader.EndOfStream)
            {
                map.Add(reader.ReadLine().Replace("\n", ""));
            }

            return map;
        }
    }
}
