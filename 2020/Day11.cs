using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    internal class Day11 : IDay
    {
        private readonly string[] _lines;

        public Day11(string path)
        {
            _lines = File.ReadAllLines(path);
        }


        public long Solve1()
        {
            var seats = _lines.Select(l => l.ToArray().ToArray()).ToArray();
            var newSeats = _lines.Select(l => l.ToArray().ToArray()).ToArray();
            var equal = true;
            do
            {
                seats = newSeats.Select(c => (char[])c.Clone()).ToArray();
                newSeats = Simulate(seats);

                equal = true;
                for (var i = 0; i < seats.Length; i++)
                {
                    if (!seats[i].SequenceEqual(newSeats[i]))
                        equal = false;
                }

            } while (!equal);

            var count = 0;

            foreach (var item in seats)
                count += item.Count(c => c == '#');

            return count;
        }

        private int CountNeightbors(char[][] seats, int row, int col)
        {
            var neightbors = 0;
            for (var i = row > 0 ? -1 : 0; i <= (row < seats.Length - 1 ? 1 : 0); i++)
            {

                for (var j = col > 0 ? -1 : 0; j <= (col < seats[row + i].Length - 1 ? 1 : 0); j++)
                {
                    if (j == 0 && i == 0)
                        continue;

                    if (seats[row + i][col + j] == '#')
                        neightbors++;
                }
            }

            return neightbors;
        }

        private char[][] Simulate(char[][] seats)
        {
            var newSeats = seats.Select(c => (char[])c.Clone()).ToArray();
            

            for (var row = 0; row < seats.Length; row++)
            {
                for (var col = 0; col < seats[row].Length; col++)
                {
                    if (seats[row][col] == '.')
                        continue;

                    var neightbors = CountNeightbors(seats, row, col);
                    if (neightbors == 0)
                        newSeats[row][col] = '#';

                    if (newSeats[row][col] == '#' && neightbors > 3)
                        newSeats[row][col] = 'L';
                }
            }

            return newSeats;
        }

        public long Solve2()
        {
            var count = 0;

            return count;
        }
    }
}
