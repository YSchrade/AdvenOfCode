using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AdventOfCode2020;


var path =  @"data\day10.txt";

var puzzle = new Day10(path);
var erg = 0L;
var s = Stopwatch.StartNew();
erg = puzzle.Solve2();
s.Stop();

Console.WriteLine(erg);
Console.WriteLine(s.Elapsed.TotalMilliseconds);


