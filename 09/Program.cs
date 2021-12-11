using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day09
{
	class Program
	{
		private static int fieldSize = 100;

		static void Main(string[] args)
		{
			string[] inputLines = File.ReadAllLines("inputData.txt");
			int[,] heightmap = CreateHeightMap(inputLines);

			DoPart1(heightmap);
		}

		private static int[,] CreateHeightMap(string[] inputLines)
		{
			int[,] heightmap = new int[fieldSize, fieldSize];

			for (int i = 0; i < fieldSize; i++)
			{
				string line = inputLines[i];

				for (int j = 0; j < fieldSize; j++)
				{
					heightmap[i, j] = int.Parse(line[j].ToString());
				}
			}

			return heightmap;
		}

		private static void DoPart1(int[,] heightmap)
		{
			List<int> lowPointValues = new();

			for (int i = 0; i < fieldSize; i++)
			{
				for (int j = 0; j < fieldSize; j++)
				{
					int pointValue = heightmap[i, j];

					int leftAdj = (j == 0) ? 99 : heightmap[i, j - 1];
					int rightAdj = (j == fieldSize - 1) ? 99 : heightmap[i, j + 1];
					int topAdj = (i == 0) ? 99 : heightmap[i - 1, j];
					int bottomAdj = (i == fieldSize - 1) ? 99 : heightmap[i + 1, j];

					if (pointValue < leftAdj && pointValue < rightAdj && pointValue < topAdj && pointValue < bottomAdj)
					{
						lowPointValues.Add(pointValue);
					}
				}
			}

			int sum = lowPointValues.Sum(x => x + 1);
			Console.WriteLine($"Part 1: result = {sum}");
		}
	}
}
