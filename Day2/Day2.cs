using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2024.Day2
{
    public class Day2
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
	    List<List<int>> reportsList = new List<List<int>>();
	    List<int> reportList = new List<int>();  	    
 
            foreach (string line in lines)
            {
                var lineSplit = line.Split(" ");
		
		foreach(var ls in lineSplit)
		{
		   // Console.Write(ls);
		    reportList.Add(int.Parse(ls));
		}
		//Console.WriteLine();	
		reportsList.Add(reportList);
		reportList.Clear();
            }
	    foreach(var report in reportsList){
		foreach(var num in report){
	 	    Console.Write(num + "-");
		}
		Console.WriteLine("new line :)");
	    }
	    
	    return 0;           
        }

        private static int Part2Calc(string[] lines)
        {
            return 0;
        }

    }

}
