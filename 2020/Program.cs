using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AdventOfCode;


string path =  @"data\day3.txt";

var puzzle = new Day3(path);
var erg = 0l;
var s = Stopwatch.StartNew();
erg = puzzle.Solve1();
s.Stop();

Console.WriteLine(erg);
Console.WriteLine(s.Elapsed.TotalMilliseconds);


