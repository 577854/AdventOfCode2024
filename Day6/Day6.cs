using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2024.Day6
{
    public class Day6
    {
        public static void Calculate()
        {
            var path = Path.GetFullPath("Day6/input/map.txt");

             // Create an instance of FileReader
            FileReader fileReader = new FileReader();
            
            string filePath = path;
        
            string[] lines = fileReader.ReadFileLines(filePath);

            Console.WriteLine("Day 6 Part 1\n------------");
            Console.WriteLine(Part1Calc(lines) + "\n------------");
            Console.WriteLine("Day 6 Part 2\n------------");
            Console.WriteLine(Part2Calc(lines) + "\n------------");
        }

        private static int Part1Calc(string[] lines)
        {

            for (int i = 0; i < lines.lengh; i++)
            {
                if(lines[i].Contains("^")){
                    var indexAt = FindGuardIndex(lines[i], '^');
                    for ( int j = i; j <= 0; j--){
                        if(lines[j].indexAt(indexAt) == '#'){
                            lines[i]
                        }
                    }
                }
                if(line.Contains(">")){

                }
                if(line.Contains("<")){

                }
                if(lines.Contains("V")){

                }

            }

            int rows = lines.Length;
            int columns = lines[0].Length;
            char[,] map = new char[rows, columns];

            //var guardSteps = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }

            return 0;
        }

        private int FindGuardIndex(string line, char c)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }

        private static int Part2Calc(string[] lines)
        {
            return 0;
        }
    }
}