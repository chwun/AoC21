using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day06
{
    class Program
    {
        private static Dictionary<int, long> numberOfTimerValues = new();

        static void Main(string[] args)
        {
            string input = File.ReadAllText("inputData.txt");


            Stopwatch sw1 = new();
            ParseInputData(input);
            sw1.Start();
            SimulateDays(80);
            long countPart1 = numberOfTimerValues.Sum(x => x.Value);
            sw1.Stop();
            Console.WriteLine($"Part 1: {countPart1} fishs ({sw1.Elapsed.TotalMilliseconds} ms)");

            Stopwatch sw2 = new();
            ParseInputData(input);
            sw2.Start();
            SimulateDays(256);
            long countPart2 = numberOfTimerValues.Sum(x => x.Value);
            sw2.Stop();
            Console.WriteLine($"Part 2: {countPart2} fishs ({sw2.Elapsed.TotalMilliseconds} ms)");
        }

        private static void ParseInputData(string input)
        {
            var timerValues = input.Split(',').Select(x => int.Parse(x));

            numberOfTimerValues.Clear();

            for (int i = 0; i < 9; i++)
            {
                numberOfTimerValues.Add(i, 0);
            }

            foreach (int timerValue in timerValues)
            {
                numberOfTimerValues[timerValue]++;
            }
        }

        private static void SimulateDays(int days)
        {
            for (int iDay = 0; iDay < days; iDay++)
            {
                long[] counts = Enumerable.Range(0, 9).Select(x => numberOfTimerValues[x]).ToArray();

                for (int i = 0; i < 9; i++)
                {
                    numberOfTimerValues[i] -= counts[i];

                    if (i == 0)
                    {
                        numberOfTimerValues[6] += counts[i];
                        numberOfTimerValues[8] += counts[i];
                    }
                    else
                    {
                        numberOfTimerValues[i - 1] += counts[i];
                    }
                }
            }
        }
    }
}
