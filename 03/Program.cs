using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
	public static void Main(string[] args)
	{
		var lines = File.ReadAllLines("inputData.txt");

		(int gamma, int epsilon) = DoPart1(lines);
		int resultPart1 = gamma * epsilon;

		(int oxygenGeneratorRating, int co2ScrubberRating) = DoPart2(lines);
		int resultPart2 = oxygenGeneratorRating * co2ScrubberRating;

		Console.WriteLine($"Part 1: gamma={gamma}, epsilon={epsilon}, result={resultPart1}");
		Console.WriteLine($"Part 2: oxygen generator rating={oxygenGeneratorRating}, co2 scrubber rating={co2ScrubberRating}, result={resultPart2}");
	}

	private static (int gamma, int epsilon) DoPart1(string[] lines)
	{
		int lineCountHalf = lines.Length / 2;
		int[] sums = new int[12];

		foreach (string line in lines)
		{
			for (int i = 0; i < 12; i++)
			{
				sums[i] += int.Parse(line[i].ToString());
			}
		}

		string gammaBinary = "";
		string epsilonBinary = "";

		foreach (int sum in sums)
		{
			if (sum >= lineCountHalf)
			{
				gammaBinary += '1';
				epsilonBinary += '0';
			}
			else
			{
				gammaBinary += '0';
				epsilonBinary += '1';
			}
		}

		return (Convert.ToInt32(gammaBinary, 2), Convert.ToInt32(epsilonBinary, 2));
	}


	private static (int oxygenGeneratorRating, int co2ScrubberRating) DoPart2(string[] lines)
	{
		List<string> filteredListOxygen = new(lines);
		List<string> filteredListScrubber = new(lines);

		bool oxygenCompleted = false;
		bool scrubberCompleted = false;

		for (int i = 0; i < 12; i++)
		{
			int sumOxygen = filteredListOxygen.Select(x => int.Parse(x[i].ToString())).Sum();
			int countOxygen = filteredListOxygen.Count();

			int sumScrubber = filteredListScrubber.Select(x => int.Parse(x[i].ToString())).Sum();
			int countScrubber = filteredListScrubber.Count();

			if (!oxygenCompleted)
			{
				if (sumOxygen >= (countOxygen / 2d))
				{
					filteredListOxygen = filteredListOxygen.Where(x => x[i] == '1').ToList();
				}
				else
				{
					filteredListOxygen = filteredListOxygen.Where(x => x[i] == '0').ToList();
				}

				if (filteredListOxygen.Count == 1)
				{
					oxygenCompleted = true;
				}
			}

			if (!scrubberCompleted)
			{
				if (sumScrubber >= (countScrubber / 2d))
				{
					filteredListScrubber = filteredListScrubber.Where(x => x[i] == '0').ToList();
				}
				else
				{
					filteredListScrubber = filteredListScrubber.Where(x => x[i] == '1').ToList();
				}

				if (filteredListScrubber.Count == 1)
				{
					scrubberCompleted = true;
				}
			}
		}

		return (Convert.ToInt32(filteredListOxygen.First(), 2), Convert.ToInt32(filteredListScrubber.First(), 2));
	}
}