using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day04
{
	public class Game
	{
		private readonly List<int> drawnNumbers = new();

		private readonly List<Board> boards = new();

		public Game(string[] gameData)
		{
			ParseGameData(gameData);
		}

		public (int winningScore, int losingScore) PlayAndGetScore()
		{
			int boardCount = boards.Count;
			Board? winningBoard = null;
			int winningNumber = -1;
			HashSet<Board> completeBoards = new();

			foreach (int drawnNumber in drawnNumbers)
			{
				foreach (Board board in boards)
				{
					if (completeBoards.Contains(board))
					{
						continue;
					}

					board.MarkNumber(drawnNumber);
					if (board.IsWinner())
					{
						if (completeBoards.Count == 0)
						{
							winningBoard = board;
							winningNumber = drawnNumber;
						}

						completeBoards.Add(board);
					}

					if (completeBoards.Count == boardCount)
					{
						return (winningBoard!.GetSumOfUnmarkedNumbers() * winningNumber, board.GetSumOfUnmarkedNumbers() * drawnNumber);
					}
				}
			}

			return (0, 0);
		}

		private void ParseGameData(string[] gameData)
		{
			Queue<string> lines = new(gameData);

			drawnNumbers.AddRange(lines.Dequeue().Split(',').Select(x => int.Parse(x)));

			while (lines.Count > 0)
			{
				string line = lines.Peek();

				if (string.IsNullOrWhiteSpace(line))
				{
					lines.Dequeue();
					continue;
				}

				IEnumerable<string> boardData = lines.DequeueChunk<string>(5);
				boards.Add(new(boardData));
			}
		}
	}
}