using System;
using System.IO;

namespace Day04
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var lines = File.ReadAllLines("inputData.txt");

			Game game = new(lines);
			(int winningScore, int losingScore) = game.PlayAndGetScore();

			Console.WriteLine($"Part 1: winning score={winningScore}");
			Console.WriteLine($"Part 2: losing score={losingScore}");
		}
	}
}