using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AdventOfCode;


string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data\day2.txt");

var puzzle = new Day2(path);
var erg = 0l;
var s = Stopwatch.StartNew();
erg = puzzle.Solve1();
s.Stop();

Console.WriteLine(erg);
Console.WriteLine(s.Elapsed.TotalMilliseconds);


