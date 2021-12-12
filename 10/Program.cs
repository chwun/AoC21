using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day10
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] inputLines = File.ReadAllLines("inputData.txt");

			(var syntaxErrorTokens, var expectedTokensForIncompleteLines) = SyntaxCheckLines(inputLines);
			int syntaxErrorScore = CalculateSyntaxErrorScore(syntaxErrorTokens);
			long autoComletionScore = CalculateAutoCompletionScore(expectedTokensForIncompleteLines);

			Console.WriteLine($"Part 1: syntax error score = {syntaxErrorScore}");
			Console.WriteLine($"Part 2: auto completion score = {autoComletionScore}");
		}

		private static (List<Token> syntaxErrorTokens, List<Stack<Token>> expectedTokensForIncompleteLines) SyntaxCheckLines(string[] lines)
		{
			List<Token> syntaxErrorTokens = new();
			List<Stack<Token>> expectedTokensForIncompleteLines = new();

			foreach (string line in lines)
			{
				bool lineIsCorrupted = false;
				Token invalidToken = Token.Undefined;

				var tokens = Tokenize(line);
				Stack<Token> expectedTokens = new();

				foreach (Token token in tokens)
				{
					if (token == Token.RoundBracketOpen)
					{
						expectedTokens.Push(Token.RoundBracketClose);
					}
					else if (token == Token.SquareBracketOpen)
					{
						expectedTokens.Push(Token.SquareBracketClose);
					}
					else if (token == Token.CurlyBracketOpen)
					{
						expectedTokens.Push(Token.CurlyBracketClose);
					}
					else if (token == Token.LessThan)
					{
						expectedTokens.Push(Token.GreaterThan);
					}
					else
					{
						Token expected = expectedTokens.Pop();

						if (token != expected)
						{
							lineIsCorrupted = true;
							invalidToken = token;
							break;
						}
					}
				}

				if (lineIsCorrupted)
				{
					syntaxErrorTokens.Add(invalidToken);
				}
				else
				{
					expectedTokensForIncompleteLines.Add(expectedTokens);
				}
			}

			return (syntaxErrorTokens, expectedTokensForIncompleteLines);
		}

		private static List<Token> Tokenize(string input)
		{
			List<Token> tokens = new();

			foreach (char c in input)
			{
				tokens.Add(c switch
				{
					'(' => Token.RoundBracketOpen,
					')' => Token.RoundBracketClose,
					'[' => Token.SquareBracketOpen,
					']' => Token.SquareBracketClose,
					'{' => Token.CurlyBracketOpen,
					'}' => Token.CurlyBracketClose,
					'<' => Token.LessThan,
					'>' => Token.GreaterThan,
					_ => throw new ArgumentException("invalid input")
				});
			}

			return tokens;
		}

		private static int CalculateSyntaxErrorScore(List<Token> syntaxErrorTokens)
		{
			int score = 0;

			foreach (Token token in syntaxErrorTokens)
			{
				score += token switch
				{
					Token.RoundBracketClose => 3,
					Token.SquareBracketClose => 57,
					Token.CurlyBracketClose => 1197,
					Token.GreaterThan => 25137,
					_ => throw new ArgumentException("invalid input")
				};
			}

			return score;
		}

		private static long CalculateAutoCompletionScore(List<Stack<Token>> expectedTokensForIncompleteLines)
		{
			List<long> scores = new();

			foreach (Stack<Token> expectedTokens in expectedTokensForIncompleteLines)
			{
				long score = 0;

				foreach (Token token in expectedTokens)
				{
					score *= 5;

					score += token switch
					{
						Token.RoundBracketClose => 1,
						Token.SquareBracketClose => 2,
						Token.CurlyBracketClose => 3,
						Token.GreaterThan => 4,
						_ => throw new ArgumentException("invalid input")
					};
				}

				scores.Add(score);
			}

			scores.Sort();

			return scores[(scores.Count - 1) / 2];
		}
	}
}