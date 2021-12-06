using System;

namespace Day05
{
    public class Line
    {
        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        public Line(string input)
        {
            Parse(input);
        }

        private void Parse(string input)
        {
            string[] points = input.Split(" -> ");
            string[] point1 = points[0].Split(',');
            string[] point2 = points[1].Split(',');

            X1 = int.Parse(point1[0]);
            Y1 = int.Parse(point1[1]);
            X2 = int.Parse(point2[0]);
            Y2 = int.Parse(point2[1]);
        }
    }

}