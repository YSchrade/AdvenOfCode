using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    internal class Day4 : IDay
    {
        private readonly List<List<(string key,string value)>> _passports;

        public Day4(string dataPath)
        {
            _passports = GetPassports(dataPath);
        }


        public long Solve1()
        {
            var count = 0;
            foreach (var passport in _passports)
            {
                if (passport.Count == 8)
                {
                    count++;
                    continue;
                }

                if (passport.Count < 7)
                    continue;

                if(!passport.Any(v => v.key == "cid"))
                    count++;
                 
            }

            return count;
        }

        public long Solve2()
        {
            var count = 0;
            foreach (var passport in _passports)
            {
                if (CheckPassport(passport))
                    count++;
            }

            return count;
        }


        private bool CheckPassport(List<(string key, string value)> passport) 
            => passport.Count == 8 && passport.All(d => ValidateKeyValue(d))
                    || passport.Count == 7 && !passport.Any(v => v.key == "cid") && passport.All(d => ValidateKeyValue(d));

        private bool ValidateKeyValue((string key, string value) data)
        {
            var key = data.key;
            var value = data.value;
            switch (key)
            {
                case "byr":
                    return int.Parse(value) is >= 1920 and <= 2002;
                case "iyr":
                    return int.Parse(value) is >= 2010 and <= 2020;
                case "eyr":
                    return int.Parse(value) is >= 2020 and <= 2030;
                case "hgt":
                    if (value.EndsWith("cm"))
                    {
                        var num = value.Replace("cm", "");
                        var erg = int.Parse(num) is >= 150 and <= 193;
                        return erg;
                    }
                    else if (value.EndsWith("in"))
                    {
                        var num = value.Replace("in", "");
                        var erg = int.Parse(num) is >= 59 and <= 76;
                        return erg;
                    }
                    else
                        return false;
                    
                case "hcl":
                    if (!value.StartsWith("#"))
                        return false;
                    var hex = value.Replace("#", "");
                    return int.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _);
                case "ecl":
                    return value is "amb" or "blu" or "brn" or "gry" or "grn" or "hzl" or "oth";

                case "pid":
                    return int.TryParse(value, out _) && value.Length == 9;
                case "cid":
                    return true;
                default:
                    throw new ArgumentOutOfRangeException(key);
            }
        }

        private List<List<(string key ,string value)>> GetPassports(string dataPath)
        {
            using var reader = new StreamReader(File.OpenRead(dataPath));

            var passports = new List<List<(string,string)>>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                
                var passport = new List<(string, string)>();
                do
                {

                    var rows = line.Split(" ");
                    foreach (var row in rows)
                    {
                        var data = row.Split(":");
                        passport.Add((data[0], data[1]));
                    }
                    line = reader.ReadLine();                    
                } while (line != string.Empty && line != null);

                passports.Add(passport);
            }

            return passports;
        }

    }
}
