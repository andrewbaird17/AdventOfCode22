using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode22.Day1
{
    public class Day1
    {
        public void RunDay1()
        {
            string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), @"Day1\input.txt");
            var text = File.ReadAllText(path);
            var splitText = text.Split("\r\n\r\n");
            var elves = new List<int>();
            for (int i = 0; i < splitText.Length; i++)
            {
                var elfTextSplit = splitText[i].Split("\r\n");
                var totalCalories = 0;
                foreach (var numString in elfTextSplit)
                {
                    var num = int.Parse(numString);
                    totalCalories += num;
                }
                elves.Add(totalCalories);
            }
            var sumOfBig = 0;
            for (int i = 0; i < 3; i++)
            {
                var elfBig = elves.Max();
                Console.WriteLine(elfBig.ToString());
                sumOfBig += elfBig;
                var numElf = elves.IndexOf(elfBig);
                elves.RemoveAt(numElf);
            }

            Console.WriteLine(sumOfBig.ToString());
        }
    }
}
