using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2024.Day5
{
    public class Day5
    {
        public static void Calculate()
        {
            var path = Path.GetFullPath("Day5/input/pages.txt");

             // Create an instance of FileReader
            FileReader fileReader = new FileReader();
            
            string filePath = path;
        
            string[] lines = fileReader.ReadFileLines(filePath);

            Console.WriteLine("Day 5 Part 1\n------------");
            Console.WriteLine(Part1Calc(lines) + "\n------------");
            Console.WriteLine("Day 5 Part 2\n------------");
            Console.WriteLine(Part2Calc(lines) + "\n------------");
        }

        private static int Part1Calc(string[] lines)
        {
            var rules = new List<Tuple<int, int>>();
            var correctPages = new List<int>();

            foreach (string line in lines)
            {
                if (line.Contains("|"))
                {
                    var lineSplit = line.Split("|");
                    rules.Add(Tuple.Create(int.Parse(lineSplit[0]), int.Parse(lineSplit[1])));
                }
                else if(line.Contains(","))
                {
                    var page = line.Split(",");
                    var followsRules = false;

                    for (int i = 0; i < page.Length; i++)
                    {
                        if (i+1 == page.Length) break;

                        followsRules = FollowsRules(int.Parse(page[i]), int.Parse(page[i+1]), rules);

                        if(!followsRules) break;
                    }
                    if(followsRules){
                        correctPages.Add(int.Parse(page[page.Length/2]));
                    }
                }
            }

            return correctPages.Sum();
        }

        private static int Part2Calc(string[] lines)
        {
            var rules = new List<Tuple<int, int>>();
            var inCorrectPages = new List<int>();

            foreach (string line in lines)
            {
                if (line.Contains("|"))
                {
                    var lineSplit = line.Split("|");
                    rules.Add(Tuple.Create(int.Parse(lineSplit[0]), int.Parse(lineSplit[1])));
                }
                else if(line.Contains(","))
                {
                    var page = Array.ConvertAll(line.Split(","), int.Parse).ToList();

                    var followsRules = true;

                    for (int i = 0; i < page.Count; i++)
                    {
                        if (i+1 == page.Count) break;

                        followsRules = FollowsRules(page[i], page[i+1], rules);

                        if(!followsRules) break;
                    }
                    if(!followsRules){
                        page = RestackedAccordingToRules(page, rules);
                        inCorrectPages.Add(page[page.Count/2]);
                    }
                }
            }

            return inCorrectPages.Sum();
        }

        private static bool FollowsRules(int num1, int num2, List<Tuple<int, int>> rules)
        {
            bool followsAllRules = true;
            foreach (var rule in rules)
            {
                if (num1 == rule.Item1 && num2 == rule.Item2){
                    followsAllRules = true;
                }
                if(num1 == rule.Item2 && num2 == rule.Item1){
                    return false;
                }
            }
            return followsAllRules;
        }

        private static List<int> RestackedAccordingToRules(List<int> list, List<Tuple<int, int>> rules)
        {
            //Use bubble sort (no idea why this worked, but it did)
            int n = list.Count;
            int i, j, temp;
            bool swapped;
            for (i = 0; i < n - 1; i++) {
                swapped = false;
                for (j = 0; j < n - i - 1; j++) {
                    if (!FollowsRules(list[j], list[j+1], rules)) {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;
            }
            return list;
        }
    }

}