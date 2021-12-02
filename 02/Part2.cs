using System;
using System.Text.RegularExpressions;

namespace Day02
{
    public class Part2
    {
        public (int horizontalPosition, int depth) ProcessCommands(string[] commands)
        {
            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;

            foreach (string command in commands)
            {
                Match matchForward = Regex.Match(command, "forward (?<value>[0-9]+)");
                if (matchForward.Success)
                {
                    int value = int.Parse(matchForward.Groups["value"].Value);
                    horizontalPosition += value;
                    depth += value * aim;
                }
                else
                {
                    Match matchDown = Regex.Match(command, "down (?<value>[0-9]+)");
                    if (matchDown.Success)
                    {
                        int value = int.Parse(matchDown.Groups["value"].Value);
                        aim += value;
                    }
                    else
                    {
                        Match matchUp = Regex.Match(command, "up (?<value>[0-9]+)");
                        if (matchUp.Success)
                        {
                            int value = int.Parse(matchUp.Groups["value"].Value);
                            aim -= value;
                        }
                    }
                }
            }

            return (horizontalPosition, depth);
        }
    }
}
