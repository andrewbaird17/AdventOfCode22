using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode22.Day2
{
    public class Day2
    {
        public void RunDay2()
        {
            string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), @"Day2\input2.txt");
            var text = File.ReadAllText(path);

            // Read in, split on return line to get each round,
            // Then for each group determine who wins, 
            // Keep a running total based off what you play and points for round
            // A Rock, B Paper, C Scissors --> Opponent
            // X Rock, Y Paper, Z Scissors --> you
            // Win = 6, Draw = 3, Loss = 0
            // ROck = 1, Paper =2, Scissors = 3

            var splitRounds = text.Split("\r\n");
            //var runningTotal = Part1(splitRounds);
            var runningTotal = Part2(splitRounds);

            Console.WriteLine(runningTotal);
        }

        public int Part2(string[] input)
        { // X = l, Y = d, Z = w
            var runningTotal = 0;
            foreach (var round in input)
            {
                var values = round.Split(" ");
                var opponent = values[0];
                var self = values[1];

                if (opponent == "A")
                {
                    if (self == "X")
                    {
                        runningTotal += 3;
                    }
                    else if (self == "Y")
                    {
                        runningTotal += 4;
                    }
                    else if (self == "Z") 
                    {
                        runningTotal += 8;
                    }
                }
                else if (opponent == "B")
                {
                    if (self == "X")
                    {
                        runningTotal += 1;
                    }
                    else if (self == "Y")
                    {
                        runningTotal += 5;
                    }
                    else if (self == "Z")
                    {
                        runningTotal += 9;
                    }
                }
                else if (opponent == "C")
                {
                    if (self == "X")
                    {
                        runningTotal += 2;
                    }
                    else if (self == "Y")
                    {
                        runningTotal += 6;
                    }
                    else if (self == "Z")
                    {
                        runningTotal += 7;
                    }
                }
            }

            return runningTotal;
        }

        public int Part1(string[] input)
        {
            var runningTotal = 0;
            foreach (var round in input)
            {
                var values = round.Split(" ");
                var opponent = values[0];
                var self = values[1];

                if ((opponent == "A" && self == "X")
                    || (opponent == "B" && self == "Y")
                    || (opponent == "C" && self == "Z"))
                {
                    runningTotal += RoundPoints("d");
                }
                else if ((opponent == "A" && self == "Z")
                    || (opponent == "B" && self == "X")
                    || (opponent == "C" && self == "Y"))
                {
                    runningTotal += RoundPoints("l");
                }
                else if ((opponent == "A" && self == "Y")
                    || (opponent == "B" && self == "Z")
                    || (opponent == "C" && self == "X"))
                {
                    runningTotal += RoundPoints("w");
                }
                runningTotal += ShapePoints(self);
            }

            return runningTotal;
        }

        public int RoundPoints(string result)
        {
            switch (result)
            {
                case "w":
                    return 6;
                case "l":
                    return 0;
                case "d":
                    return 3;
                default:
                    return 0;
            }
        }

        public int ShapePoints(string shape)
        {
            switch (shape)
            {
                case "X":
                    return 1;
                case "Y":
                    return 2;
                case "Z":
                    return 3;
                default:
                    return 0;
            }
        }
    }
}
