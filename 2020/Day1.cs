using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    internal class Day1 : IDay
    {
        private readonly List<int> _data = new List<int>();

        public Day1(string dataPath)
        {
            using var reader = new StreamReader(File.OpenRead(dataPath));

            while (!reader.EndOfStream)
            {
                var text = reader.ReadLine();
                _data.Add(int.Parse(text));
            }
        }


        public long Solve1()
        {
            var checkdata = new List<int>(_data);
            var erg = 0;
            foreach (var firstnum in _data)
            {
                foreach (var secondnum in checkdata)
                {
                    if (firstnum + secondnum == 2020)
                    {
                        erg = firstnum * secondnum;
                        break;
                    }


                }
                if (erg != 0)
                    break;
            }

            return erg;
        }

        public long Solve2()
        {
            var firstData = _data;
            var secondData = new List<int>(_data);
            var thirdData = new List<int>(_data);
            var erg = 0;
            foreach (var first in firstData)
            {
                foreach (var second in secondData)
                {
                    foreach (var third in thirdData)
                    {
                        if (first + second + third == 2020)
                        {
                            erg = first * second * third;
                            break;
                        }
                    }

                    if (erg != 0)
                        break;
                }
                if (erg != 0)
                    break;

            }

            return erg;
        }
    }
}
