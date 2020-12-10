using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AdventOfCode;


var path =  @"data\day8.txt";

var puzzle = new Day8(path);
var erg = 0l;
var s = Stopwatch.StartNew();
erg = puzzle.Solve1();
s.Stop();

Console.WriteLine(erg);
Console.WriteLine(s.Elapsed.TotalMilliseconds);


