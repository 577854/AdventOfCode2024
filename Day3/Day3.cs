using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3
{
    public class Day3
    {
        public static void Calculate()
        {
            var path = Path.GetFullPath("Day3/input/input.txt");

             // Create an instance of FileReader
            FileReader fileReader = new FileReader();
            
            string filePath = path;
        
            string[] lines = fileReader.ReadFileLines(filePath);

            Console.WriteLine("Day 3 Part 1\n------------");
            Console.WriteLine(Part1Calc(lines) + "\n------------");
            Console.WriteLine("Day 3 Part 2\n------------");
            Console.WriteLine(Part2Calc(lines) + "\n------------");
        }

        private static int Part1Calc(string[] lines)
        {
            string linesCombined = String.Join("", lines);
            //Console.Write(linesCombined);

            Regex regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

            List<string> muls = new List<string>();

            MatchCollection matches = regex.Matches(linesCombined);
                
            foreach(Match match in matches)
            {
                muls.Add(match.Value);
            }

            var answer = 0;
            foreach(var mul in muls)
            {
                var nums = mul.Substring(4).Split(",");
                var res = int.Parse(nums[0]) * int.Parse(nums[1].Replace(")", ""));
                
                answer += res;
            }

            return answer;
        }

        private static int Part2Calc(string[] lines)
        {
            string linesCombined = String.Join("", lines);
            //Console.Write(linesCombined);

            Regex regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)");

            List<string> muls = new List<string>();

            MatchCollection matches = regex.Matches(linesCombined);
                
            foreach(Match match in matches)
            {
                muls.Add(match.Value);
            }

            var answer = 0;
            var keepGoing = true;
            foreach(var mul in muls)
            {
                if(mul == "do()")
                {
                    keepGoing = true;
                }
                else if(mul == "don't()")
                {
                    keepGoing = false;
                }
                
                if(keepGoing && mul.StartsWith("mul"))
                {
                    var nums = mul.Substring(4).Split(",");
                    var res = int.Parse(nums[0]) * int.Parse(nums[1].Replace(")", ""));
                    answer += res;
                }
            }

            return answer;
        }

    }

}