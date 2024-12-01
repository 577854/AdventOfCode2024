using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2024.Day2
{
    public class Day1
    {
        public static void Calculate()
        {
            var path = Path.GetFullPath("Day2/input/part1Input.txt");

             // Create an instance of FileReader
            FileReader fileReader = new FileReader();
            
            string filePath = path;
        
            string[] lines = fileReader.ReadFileLines(filePath);

            Console.WriteLine("Day 2 Part 1\n------------");
            Console.WriteLine(Part1Calc(lines) + "\n------------");
            Console.WriteLine("Day 2 Part 2\n------------");
            Console.WriteLine(Part2Calc(lines) + "\n------------");
        }

        private static int Part1Calc(string[] lines)
        {
           
        }

        private static int Part2Calc(string[] lines)
        {
            
        }

    }

}