using System.Collections.Generic;
using System.Linq;

namespace Day04
{
	public class Board
	{
		private readonly int[,] numbers = new int[5, 5];

		public Board(IEnumerable<string> boardData)
		{
			ParseBoardData(boardData.ToArray());
		}

		public void MarkNumber(int drawnNumber)
		{
			for (int iRow = 0; iRow < 5; iRow++)
			{
				for (int iCol = 0; iCol < 5; iCol++)
				{
					if (numbers[iRow, iCol] == drawnNumber)
					{
						numbers[iRow, iCol] = -1;
					}
				}
			}
		}

		public bool IsWinner()
		{
			for (int iRow = 0; iRow < 5; iRow++)
			{
				int rowSum = Enumerable.Range(0, 5).Select(x => numbers[iRow, x]).Sum();

				if (rowSum < 0)
				{
					return true;
				}
			}

			for (int iCol = 0; iCol < 5; iCol++)
			{
				int colSum = Enumerable.Range(0, 5).Select(x => numbers[x, iCol]).Sum();

				if (colSum < 0)
				{
					return true;
				}
			}

			return false;
		}

		public int GetSumOfUnmarkedNumbers()
		{
			int sum = 0;

			for (int iRow = 0; iRow < 5; iRow++)
			{
				for (int iCol = 0; iCol < 5; iCol++)
				{
					if (numbers[iRow, iCol] != -1)
					{
						sum += numbers[iRow, iCol];
					}
				}
			}

			return sum;
		}

		private void ParseBoardData(string[] boardData)
		{
			for (int iRow = 0; iRow < 5; iRow++)
			{
				string line = boardData[iRow];
				int[] lineNumbers = line.Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray();
				for (int iCol = 0; iCol < 5; iCol++)
				{
					numbers[iRow, iCol] = lineNumbers[iCol];
				}
			}
		}
	}
}