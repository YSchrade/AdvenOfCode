using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;

namespace AdventOfCode
{
    internal class Day2 : IDay
    {
        private readonly List<Data> _dataList;

        public Day2(string dataPath)
        {
            _dataList = LoadData(dataPath);
        }


        public long Solve1()
        {
            var count = 0;
            foreach (var data in _dataList)
            {
                var num = data.PassWd.Count(c => c == data.Char);
                if (num >= data.NumOne && num <= data.NumTwo)
                    count++;
            }
            return count;
        }

        public long Solve2()
        {
            var count = 0;
            foreach (var data in _dataList)
            {
                var valid = false;
                if (data.PassWd[data.NumOne -1] == data.Char)
                    valid = !valid;

                if (data.PassWd[data.NumTwo -1] == data.Char)
                    valid = !valid;

                if (valid)
                    count++;
            }

            return count;
        }

        private List<Data> LoadData(string dataPath)
        {
            var dataList = new List<Data>();

            using var reader = new StreamReader(File.OpenRead(dataPath));

            while (!reader.EndOfStream)
            {
                var row = reader.ReadLine();
                var splittedRow = row.Split(" ");
                var numbers = splittedRow[0].Split("-");
                var min = int.Parse(numbers[0]);
                var max = int.Parse(numbers[1]);

                var _char = splittedRow[1].Replace(":", "").ToCharArray()[0];

                var passWd = splittedRow[2];

                dataList.Add(new Data(passWd, _char, min, max));
            }

            return dataList;
        }


        private record Data(string PassWd, char Char, int NumOne, int NumTwo);

    }
}
