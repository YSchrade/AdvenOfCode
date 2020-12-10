using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdventOfCode
{
    internal class Day8 : IDay
    {

        private readonly string[] _lines;
        private readonly List<int> _executedLines = new List<int>();

        public Day8(string path)
        {
            _lines = File.ReadAllLines(path);
        }

        public long Solve1()
        {
            var code = new Dictionary<int, (string, int)>();

            for (var i = 0; i < _lines.Length; i++)
            {
                var regex = Regex.Match(_lines[i], @"([a-zA-Z]{3})\s([-|+]\d+)");
                var command = regex.Groups[1].Value;
                var number = int.Parse(regex.Groups[2].Value);
                code[i] = (command, number);
            }
                

            return ExecuteCode(0, code, out _);
         
        }


        public long Solve2()
        {
            var code = new Dictionary<int, (string cmd, int nbr)>();
            for (var i = 0; i < _lines.Length; i++)
            {
                var regex = Regex.Match(_lines[i], @"([a-zA-Z]{3})\s([-|+]\d+)");
                var command = regex.Groups[1].Value;
                var number = int.Parse(regex.Groups[2].Value);
                code[i] = (command, number);
            }

            foreach ((var line, var instr) in code.Where(c => c.Value.cmd == "jmp" || c.Value.cmd == "nop"))
            {
                var newCode = new Dictionary<int, (string, int)>(code);
                bool corrupt;
                var erg = 0;

                if(instr.cmd == "jmp")
                {
                    newCode[line] = ("nop", instr.nbr);
                    erg = ExecuteCode(0, newCode, out corrupt);
                }
                else
                {
                    newCode[line] = ("jmp", instr.nbr);
                    erg = ExecuteCode(0, newCode, out corrupt);
                }
                
                if (!corrupt)
                    return erg;

            }

            return -1;
        }



        
        private int ExecuteCode(int line, Dictionary<int, (string, int)> code, out bool corrupt)
        {
            corrupt = true;
            var acc = 0;
            if (_executedLines.Contains(line))
            {
                _executedLines.Clear();
                return acc;
            }
                

            if(line == code.Count)
            {
                corrupt = false;
                return acc;
            }

            (var cmd, var nbr) = code[line];
                
            _executedLines.Add(line);
            switch (cmd)
            {
                case "nop":
                    acc += ExecuteCode(++line, code, out corrupt);
                    break;

                case "jmp":
                    acc += ExecuteCode(line + nbr, code, out corrupt);
                    break;

                case "acc":
                    acc += nbr;
                    acc += ExecuteCode(++line, code, out corrupt);
                    break;
                default:
                    break;
            }

            return acc;
        }
    }
}
