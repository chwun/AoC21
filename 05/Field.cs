using System;

namespace Day05
{
    public class Field
    {
        private readonly int[,] positions = new int[1000, 1000];

        public Field()
        {

        }

        public void AddLineIfStraight(Line line)
        {
            if (line.X1 == line.X2)
            {
                int minY = Math.Min(line.Y1, line.Y2);
                int maxY = Math.Max(line.Y1, line.Y2);

                for (int i = minY; i <= maxY; i++)
                {
                    positions[line.X1, i]++;
                }
            }
            else if (line.Y1 == line.Y2)
            {
                int minX = Math.Min(line.X1, line.X2);
                int maxX = Math.Max(line.X1, line.X2);

                for (int i = minX; i <= maxX; i++)
                {
                    positions[i, line.Y1]++;
                }
            }
        }

        public void AddLine(Line line)
        {
            if (line.X1 == line.X2)
            {
                int minY = Math.Min(line.Y1, line.Y2);
                int maxY = Math.Max(line.Y1, line.Y2);

                for (int i = minY; i <= maxY; i++)
                {
                    positions[line.X1, i]++;
                }
            }
            else if (line.Y1 == line.Y2)
            {
                int minX = Math.Min(line.X1, line.X2);
                int maxX = Math.Max(line.X1, line.X2);

                for (int i = minX; i <= maxX; i++)
                {
                    positions[i, line.Y1]++;
                }
            }
            else
            {
                int minX = Math.Min(line.X1, line.X2);
                int maxX = Math.Max(line.X1, line.X2);

                int numberOfPoints = Math.Abs(line.X1 - line.X2) + 1;

                int currentX = line.X1;
                int currentY = line.Y1;

                for (int i = 0; i < numberOfPoints; i++)
                {
                    positions[currentX, currentY]++;

                    if (line.X1 < line.X2)
                    {
                        currentX++;
                    }
                    else
                    {
                        currentX--;
                    }

                    if (line.Y1 < line.Y2)
                    {
                        currentY++;
                    }
                    else
                    {
                        currentY--;
                    }
                }
            }
        }

        public int GetNumberOfPositionsWithAtLeastTwoOverlappingLines()
        {
            int result = 0;

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    if (positions[x, y] >= 2)
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}