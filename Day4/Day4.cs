using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2024.Day4
{
    public class Day4
    {
        public static void Calculate()
        {
            var path = Path.GetFullPath("Day4/input/xmas.txt");

             // Create an instance of FileReader
            FileReader fileReader = new FileReader();
            
            string filePath = path;
        
            string[] lines = fileReader.ReadFileLines(filePath);

            Console.WriteLine("Day 4 Part 1\n------------");
            Console.WriteLine(Part1Calc(lines) + "\n------------");
            Console.WriteLine("Day 4 Part 2\n------------");
            Console.WriteLine(Part2Calc(lines) + "\n------------");
        }

        private static int Part1Calc(string[] lines)
        {
            int rows = lines.Length;
            int columns = lines[0].Length;
            char[,] crosswords = new char[rows, columns];

            var xmasCount = 0;

             for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    crosswords[i, j] = lines[i][j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //-->
                    if(i + 3 < rows && checkIf_XMAS(new char[] {crosswords[i, j], crosswords[i + 1, j], crosswords[i + 2, j], crosswords[i + 3, j]})) xmasCount++;
                    //<--
                    if(i - 3 >= 0 && checkIf_XMAS(new char[] {crosswords[i, j], crosswords[i - 1, j], crosswords[i - 2, j], crosswords[i - 3, j]})) xmasCount++;
                    //  |
                    // \|/
                    if(j + 3 < columns && checkIf_XMAS(new char[] {crosswords[i, j], crosswords[i, j+1], crosswords[i, j+2], crosswords[i, j+3]})) xmasCount++;
                    // /|\
                    //  |
                    if(j - 3 >= 0 && checkIf_XMAS(new char[] {crosswords[i, j], crosswords[i, j-1], crosswords[i, j-2], crosswords[i, j-3]})) xmasCount++;
                    //  \
                    //  `\`
                    if(i + 3 < rows && j + 3 < columns && checkIf_XMAS(new char[] {crosswords[i, j], crosswords[i + 1, j + 1], crosswords[i + 2, j + 2], crosswords[i + 3, j + 3]})) xmasCount++;
                    //  `/`
                    //  /
                    if(i + 3 < rows && j - 3 >= 0 && checkIf_XMAS(new char[] {crosswords[i, j], crosswords[i + 1, j - 1], crosswords[i + 2, j - 2], crosswords[i + 3, j - 3]})) xmasCount++;
                    //   /
                    // `/`
                    if(i - 3 >= 0 && j + 3 < columns && checkIf_XMAS(new char[] {crosswords[i, j], crosswords[i - 1, j + 1], crosswords[i - 2, j + 2], crosswords[i - 3, j + 3]})) xmasCount++;
                    // `\`
                    //   \
                    if(i - 3 >= 0 && j - 3 >= 0 && checkIf_XMAS(new char[] {crosswords[i, j], crosswords[i - 1, j - 1], crosswords[i - 2, j - 2], crosswords[i - 3, j - 3]})) xmasCount++;

                    //Console.Write(crosswords[i, j]);
                }
                //Console.WriteLine();
            }

            return xmasCount;
        }

        private static bool checkIf_XMAS(char[] word)
        {
            if(word[0] == 'X' && word[1] == 'M' && word[2] == 'A' && word[3] == 'S') return true;
            
            return false;
        }

        private static int Part2Calc(string[] lines)
        {
            int rows = lines.Length;
            int columns = lines[0].Length;
            char[,] crosswords = new char[rows, columns];

            var xmasCount = 0;

             for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    crosswords[i, j] = lines[i][j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(crosswords[i, j] == 'A' && i - 1 >= 0 && i + 1 < rows && j - 1 >= 0 && j + 1 < columns && checkIf_MAS(
                        new char[,] {
                            {crosswords[i-1, j-1], crosswords[i-1, j], crosswords[i-1, j+1]},
                            {crosswords[i, j-1], crosswords[i, j], crosswords[i, j+1]},
                            {crosswords[i+1, j-1], crosswords[i+1, j], crosswords[i+1, j+1]},
                        }))
                        {
                            xmasCount++;
                        }
                        
                    //Console.Write(crosswords[i, j]);
                }
                //Console.WriteLine();
            }

            return xmasCount;
        }

        private static bool checkIf_MAS(char[,] words)
        {
            //M . S
            //. A .
            //M . S
            if (words[0,0] == 'M' && words[0,2] == 'S' && words[2,0] == 'M' && words[2,2] == 'S') return true;
            // M . M
            // . A .
            // S . S
            if (words[0,0] == 'M' && words[0,2] == 'M' && words[2,0] == 'S' && words[2,2] == 'S') return true;
            //S . S
            //. A .
            //M . M
            if (words[0,0] == 'S' && words[0,2] == 'S' && words[2,0] == 'M' && words[2,2] == 'M') return true; 
            //S . M
            //. A .
            //S . M
            if (words[0,0] == 'S' && words[0,2] == 'M' && words[2,0] == 'S' && words[2,2] == 'M') return true;
            
            return false;
        }

    }

}