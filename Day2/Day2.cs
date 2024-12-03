using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2024.Day2
{
    public class Day2
    {
        public static void Calculate()
        {
            var path = Path.GetFullPath("Day2/input/part1input.txt");

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
	        return CalculateSafeReports(reportsList, new List<List<int>>());           
        }

        private static int Part2Calc(string[] lines)
        {
            List<List<int>> reportsList = new List<List<int>>();
	        List<int> reportList = new List<int>();  	    

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

            //foreach (var report in reportsList)
            //{
            //    foreach (var num in report){
            //        Console.Write(num + " ");
            //    }
            //    Console.WriteLine();
            //}

            var unsafeReports = new List<List<int>>();

	        var safeReports = CalculateSafeReports(reportsList, unsafeReports);

            foreach (var rep in unsafeReports)
            {                
                //foreach(var num in rep){Console.Write(num + " ");}
                //Console.WriteLine("\n---------");
                for (int i = 0; i < rep.Count; i++)
                {
                    List<int> modifiedList = new List<int>(rep);
                    modifiedList.RemoveAt(i);
                    
                    //foreach(var num in modifiedList){Console.Write(num + " ");}
                    //Console.Write("|");
                    
                    if(IsSafeReport(modifiedList))
                    {
                        safeReports++;
                        //Console.Write($"SAFE BY REMOVING INDEX {i}          ");
                        break;
                    }
                }
                //Console.Write("UNSAFE");
                //Console.WriteLine("\n---------");
            }   
            return safeReports;
        }

        private static int CalculateSafeReports(List<List<int>> reportsList, List<List<int>> unsafeReports)
        {
            var safeReports = 0;

            foreach (var report in reportsList)
            {
                if (IsSafeReport(report))
                {
                    safeReports++;
                }
                else
                {
                    unsafeReports.Add(report);
                }
            }

            return safeReports;
        }

        private static bool IsSafeReport(List<int> report)
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

                    if ((Math.Abs(diff) < 1 || Math.Abs(diff) > 3))
                    {
                        notSafe = true;
                        break;
                    }
                }

                if(!notSafe && (diffList.All(n => n < 0) || diffList.All(n => n > 0)))
                {
                    return true;
                }
            
            return false;
        }

    }

}
