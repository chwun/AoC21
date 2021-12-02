using System;
using System.IO;

namespace Day02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("inputData.txt");

            Part1 part1 = new();
            (int horizontalPosition1, int depth1) = part1.ProcessCommands(lines);
            int resultPart1 = horizontalPosition1 * depth1;

            Part2 part2 = new();
            (int horizontalPosition2, int depth2) = part2.ProcessCommands(lines);
            int resultPart2 = horizontalPosition2 * depth2;

            Console.WriteLine($"Part 1: horizontal pos={horizontalPosition1}, depth={depth1}, result={resultPart1}");
            Console.WriteLine($"Part 2: horizontal pos={horizontalPosition2}, depth={depth2}, result={resultPart2}");
        }
    }
}
