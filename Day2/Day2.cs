using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2024.Day2
{
    public class Day2
    {
        public static void Calculate()
        {
            var path = Path.GetFullPath("Day2/input/Test.txt");

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

            int safeReports = 0;

            foreach (string line in lines)
            {
                var lineSplit = line.Split(" ");

                foreach(var ls in lineSplit)
		        {
		            reportList.Add(int.Parse(ls));
		        }

                reportsList.Add(reportList);
                reportList = new List<int>();
            }

            foreach (var report in reportsList)
            {
                bool notSafe = false;
                var diffList = new List<int>();

                for (int i = 0; i < report.Count; i++)
                {
                    if(i + 1 == report.Count)
                    {
                        break;
                    } 
                    
                    var diff = report[i] - report[i + 1];

                    diffList.Add(diff);

                    if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                    {
                        notSafe = true;
                        break;
                    }
                }

                if(!notSafe && (diffList.All(n => n < 0) || diffList.All(n => n > 0)))
                {
                    safeReports++;
                } 
                    
            }
	        return safeReports;           
        }

        private static int Part2Calc(string[] lines)
        {
            List<List<int>> reportsList = new List<List<int>>();
	        List<int> reportList = new List<int>();  	    

            int safeReports = 0;

            foreach (string line in lines)
            {
                var lineSplit = line.Split(" ");

                foreach(var ls in lineSplit)
		        {
		            reportList.Add(int.Parse(ls));
		        }

                reportsList.Add(reportList);
                reportList = new List<int>();
            }

            foreach (var report in reportsList)
            {
                foreach (var num in report){
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }

            string bleh = "";
            foreach (var report in reportsList)
            {
                bool notSafe = false;
                var diffList = new List<int>();
                var tolerate = true; 
                
                for (int i = 0; i < report.Count; i++)
                {
                    if(i + 1 == report.Count)
                    {
                        bleh += report[i];    
                        break;
                    } 
                    
                    var diff = report[i] - report[i + 1];

                    diffList.Add(diff);

                    bleh += report[i] + " (" + diff +") ";

                    if ((Math.Abs(diff) < 1 || Math.Abs(diff) > 3))
                    {
                        if(tolerate){
                            bleh += $"(R {report[i + 1]}) | ";
                            report.RemoveAt(i);
                            diffList.RemoveAt(diffList.Count - 1);
                            i -= 1;
                            tolerate = false;
                            continue;
                        }
                        notSafe = true;
                        bleh += $"{report[i+1]}";
                        break;
                    }
                }

                if(!notSafe && (diffList.All(n => n < 0) || diffList.All(n => n > 0)))
                {
                    safeReports++;
                    bleh += " - SAFE\n";
                }
                else{
                    bleh += " - UNSAFE\n";
                }
            }
            Console.WriteLine(bleh);
	        return safeReports; 
        }

    }

}
