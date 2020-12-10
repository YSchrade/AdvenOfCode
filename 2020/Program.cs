using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AdventOfCode;


var path =  @"data\day7.txt";

var puzzle = new Day7(path);
var erg = 0l;
var s = Stopwatch.StartNew();
erg = puzzle.Solve1();
s.Stop();

Console.WriteLine(erg);
Console.WriteLine(s.Elapsed.TotalMilliseconds);


