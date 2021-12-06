using System;
using System.IO;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("inputData.txt");

            Field fieldPart1 = new();
            Field fieldPart2 = new();

            foreach (string inputLine in lines)
            {
                Line line = new(inputLine);
                fieldPart1.AddLineIfStraight(line);
                fieldPart2.AddLine(line);
            }

            int resultPart1 = fieldPart1.GetNumberOfPositionsWithAtLeastTwoOverlappingLines();
            int resultPart2 = fieldPart2.GetNumberOfPositionsWithAtLeastTwoOverlappingLines();

            Console.WriteLine($"Part 1: points with at least two overlapping lines: {resultPart1}");
            Console.WriteLine($"Part 2: points with at least two overlapping lines: {resultPart2}");
        }
    }
}
