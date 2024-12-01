using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2024.Day1
{
    public class Day1
    {
        public static void CalculatePart1()
        {
            var path = Path.GetFullPath("Day1/input/part1Input.txt");

             // Create an instance of FileReader
            FileReader fileReader = new FileReader();
            
            string filePath = path;
        
            string[] lines = fileReader.ReadFileLines(filePath);

            Console.WriteLine("Day 1 Part 1\n------------");
            Console.WriteLine(Part1Calc(lines) + "\n------------");
            Console.WriteLine("Day 1 Part 2\n------------");
            Console.WriteLine(Part2Calc(lines) + "\n------------");
        }

        private static int Part1Calc(string[] lines)
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            foreach (string line in lines)
            {
                var lineSplit = line.Split("   ");
                
                leftList.Add(int.Parse(lineSplit[0]));
                rightList.Add(int.Parse(lineSplit[1]));
            }

            leftList.Sort();
            rightList.Sort();

            List<int> differenceList = new List<int>();

            for (int i = 0; i < leftList.Count; i++) 
            {
                differenceList.Add(Math.Abs(leftList[i] - rightList[i]));
            }

            return differenceList.Sum();
        }

        private static int Part2Calc(string[] lines)
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            foreach (string line in lines)
            {
                var lineSplit = line.Split("   ");
                
                leftList.Add(int.Parse(lineSplit[0]));
                rightList.Add(int.Parse(lineSplit[1]));
            }

            leftList.Sort();
            rightList.Sort();

            List<int> similarityList = new List<int>();

            foreach (var l in leftList) 
            {
                var appears = 0;
                foreach (var r in rightList) 
                {
                    if (l == r)
                    {
                        appears++;
                    }
                }

                similarityList.Add(l * appears);
            }

            return similarityList.Sum();
        }

    }

}