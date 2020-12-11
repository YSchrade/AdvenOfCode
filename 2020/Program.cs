using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AdventOfCode2020;


var path =  @"data\day11.txt";

var puzzle = new Day11(path);
var erg = 0L;
var s = Stopwatch.StartNew();
erg = puzzle.Solve1();
s.Stop();

Console.WriteLine(erg);
Console.WriteLine(s.Elapsed.TotalMilliseconds);


