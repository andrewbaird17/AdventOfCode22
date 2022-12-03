using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode22.Day3
{
    public class Day3
    {
        public void RunDay3()
        {
            string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), @"Day3\input.txt");
            var text = File.ReadAllText(path);
            var sacks = text.Split("\r\n");
            var priorityTotal = 0;

            //priorityTotal = Part1(sacks);
            priorityTotal = Part2(sacks);

            Console.Write(priorityTotal);
        }

        public int Part2(string[] sacks)
        {
            var priorityTotal = 0;
            List<char> elf1 = new List<char>();
            List<char> elf2 = new List<char>();
            List<char> elf3 = new List<char>();

            for (int i = 0; i < sacks.Length; i += 3)
            {
                elf1 = sacks[i].ToCharArray().ToList();
                elf2 = sacks[i + 1].ToCharArray().ToList();
                elf3 = sacks[i + 2].ToCharArray().ToList();

                var duplicates = elf1.Intersect(elf2).Intersect(elf3).ToList();
                foreach (var letter in duplicates)
                {
                    priorityTotal += GetPriorization(letter);
                }
            }

            return priorityTotal;
        }

        public int Part1(string[] sacks)
        {
            var priorityTotal = 0;

            foreach (var sack in sacks)
            {
                var sack2 = sack.Substring(sack.Length / 2);
                var sackPart2 = sack.Substring(sack.Length / 2).ToCharArray().ToList();
                var sackPart1 = sack.Split(sack2)[0].ToCharArray().ToList();
                var duplicates = sackPart1.Intersect(sackPart2).ToList();
                foreach (var letter in duplicates)
                {
                    priorityTotal += GetPriorization(letter);
                }
            }

            return priorityTotal;
        }

        public int GetPriorization(char letter)
        {
            if (char.IsUpper(letter))
            {
                return (int)letter - 38;
            }
            else
            {
                return (int)letter - 96;
            }
        }
    }
}
