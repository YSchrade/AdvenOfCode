using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    internal class Day5 : IDay
    {
        private readonly string[] _lines;
        public Day5(string path)
        {
            _lines = File.ReadAllLines(path);
        }

        public long Solve1()
        {
            var maxId = 0;
            foreach (var line in _lines)
            {
                var minRow = 0;
                var maxRow = 127;
                var minColumn = 0;
                var maxColumn = 8;
                foreach (var c in line)
                {
                    switch (c)
                    {
                        case 'F':
                            maxRow = minRow + (maxRow - minRow) / 2;
                            break;

                        case 'B':
                            minRow += (int)Math.Ceiling((maxRow - minRow) / 2.0);
                            break;

                        case 'L':
                            maxColumn = minColumn + (maxColumn - minColumn) / 2;
                            break;

                        case 'R':
                            minColumn += (int)Math.Ceiling((maxColumn - minColumn) / 2.0);
                            break;
                        default:
                            break;

                    }
                }

                var id = Math.Min(maxRow, minRow) * 8 + Math.Min(maxColumn, minColumn);
                maxId = id > maxId ? id : maxId;

            }

            return maxId;
        }


        public long Solve2()
        {
            var ids = new List<int>();
            foreach (var line in _lines)
            {
                var minRow = 0;
                var maxRow = 127;
                var minColumn = 0;
                var maxColumn = 8;
                foreach (var c in line)
                {
                    switch (c)
                    {
                        case 'F':
                            maxRow = minRow + (maxRow - minRow) / 2;
                            break;

                        case 'B':
                            minRow += (int)Math.Ceiling((maxRow - minRow) / 2.0);
                            break;

                        case 'L':
                            maxColumn = minColumn + (maxColumn - minColumn) / 2;
                            break;

                        case 'R':
                            minColumn += (int)Math.Ceiling((maxColumn - minColumn) / 2.0);
                            break;
                        default:
                            break;

                    }
                }
                ids.Add(Math.Min(maxRow, minRow) * 8 + Math.Min(maxColumn, minColumn));
            }

            
            ids.Sort();
            var myID = 0;
            for (var i = 1; i < ids.Count; i++)
            {
                if(ids[i-1] != ids[i] -1)
                {
                    myID = ids[i] - 1;
                    break;
                }
                if(ids[i+1] != ids[i] + 1)
                {
                    myID = ids[i] +1;
                    break;
                }

            }

            return myID;
        }
    }
}
