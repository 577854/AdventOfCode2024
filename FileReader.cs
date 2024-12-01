using System;
using System.IO;

namespace AdventOfCode2024
{

    public class FileReader
    {
        public string[] ReadFileLines(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return File.ReadAllLines(filePath);
                }
                else
                {
                    throw new FileNotFoundException("The specified file does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Array.Empty<string>(); // Return an empty array in case of an error.
            }
        }
    }

}