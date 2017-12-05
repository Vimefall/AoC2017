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

        public static int SummeraJamntDelbaraTal(string[] indata)
        {
            int result = 0;

            foreach (var row in indata)
            {
                var numbers = row.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                bool rowComplete = false;

                for (int i = 0; i < numbers.Count; i++)
                {
                    for (int j = 0; j < numbers.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        if (numbers[i] % numbers[j] == 0)
                        {
                            result += numbers[i] / numbers[j];
                            rowComplete = true;
                            break;
                        }

                    }
                    if (rowComplete)
                    {
                        break;
                    }
                }

            }

            return result;
        }

        public static int SummeraJamntDelbaraTal2(string[] indata)
        {
            int result = 0;

            foreach (var row in indata)
            {
                var numbers = row.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                for (int i = 0; i < numbers.Count; i++)
                {
                    int currentNumber = numbers[i];

                    int evenlyDivisiveNumber = numbers.Where((n, index) => i != index).FirstOrDefault(x => currentNumber % x == 0);

                    if (evenlyDivisiveNumber != 0)
                    {
                        result += currentNumber / evenlyDivisiveNumber;
                        break;
                    }
                }

            }

            return result;
        }
    }

    public class Day2Tests
    {
        [Fact]
        public void Part1_Test()
        {
            string data = "1    5 3" + Environment.NewLine +         // 4
                          "2    4       8" + Environment.NewLine +   // 6
                          "1 2 3";                                   // 2   -> sum == 12

            var rows = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);


            Day2.SummeraSkillnader(rows).Should().Be(12);
        }

        [Fact]
        public void Day2_Part1_Solution()
        {
            var lines = File.ReadAllLines(@"Day2\puzzle_input.txt");

            Day2.SummeraSkillnader(lines).Should().Be(44216);
        }

        [Fact]
        public void Part2_Test_v1()
        {
            string data = "2 5 3 4" + Environment.NewLine +   // 2
                          "3 4 7 16" + Environment.NewLine +  // 4
                          "3 7 14";                           // 2    -> sum == 8

            var rows = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Day2.SummeraJamntDelbaraTal(rows).Should().Be(8);
        }

        [Fact]
        public void Day2_Part2_Solution_v1()
        {
            var lines = File.ReadAllLines(@"Day2\puzzle_input.txt");

            Day2.SummeraJamntDelbaraTal(lines).Should().Be(320);
        }

        [Fact]
        public void Part2_Test_v2()
        {
            string data = "2 5 3 4" + Environment.NewLine +   // 2
                          "3 4 7 16" + Environment.NewLine +  // 4
                          "3 7 14";                           // 2    -> sum == 8
             
            var rows = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Day2.SummeraJamntDelbaraTal2(rows).Should().Be(8);
        }

        [Fact]
        public void Day2_Part2_Solution_v2()
        {
            var lines = File.ReadAllLines(@"Day2\puzzle_input.txt");

            Day2.SummeraJamntDelbaraTal2(lines).Should().Be(320);
        }
    }
}