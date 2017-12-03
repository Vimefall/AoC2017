using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2017.Day2
{
    public class Day2
    {
        public static int SummeraSkillnader(string[] indata)
        {
            int result = 0;

            foreach (var row in indata)
            {
                var numbers = row.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                int difference = numbers.Max() - numbers.Min();

                result += difference;
            }

            return result;
        }
    }

    public class Day2Tests
    {
        [Fact]
        public void Test1()
        {
            string data = "1    5 3" + Environment.NewLine + // 4
                          "2    4       8" + Environment.NewLine +   // 6
                          "1 2 3";      // 2

            var rows = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);


            Day2.SummeraSkillnader(rows).Should().Be(12);
        }

        [Fact]
        public void Day2_Solution()
        {
            var lines = File.ReadAllLines(@"Day2\puzzle_input.txt");

            Day2.SummeraSkillnader(lines).Should().Be(44216);
        }

    }
}