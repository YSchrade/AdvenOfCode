using System;
using System.Diagnostics;
using AdventOfCode;



var path = @"data/day1.txt";

var puzzle = new Day1(path);
var erg = 0l;
var s = Stopwatch.StartNew();
erg = puzzle.Solve1();
s.Stop();

Console.WriteLine(erg);
Console.WriteLine(s.Elapsed.TotalMilliseconds);


