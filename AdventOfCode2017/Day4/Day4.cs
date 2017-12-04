using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2017.Day4
{
    public class Day4
    {
        public static int GetValidPassphrases_Part1(string[] lines)
        {
            int validPhraseCount = 0;

            foreach (var line in lines)
            {
                List<string> words = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).ToList();

                var foundDuplicate = words.GroupBy(x => x).Any(g => g.Count() > 1);

                if (!foundDuplicate)
                {
                    validPhraseCount++;
                }
            }

            return validPhraseCount;
        }

        public static int GetValidPassphrases_Part2(string[] lines)
        {
            return lines.Count(IsLineValid);
        }

        public static bool IsLineValid(string line)
        {
            List<string> words = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).ToList();

            var sortedWords = words.Select(w => new string(w.OrderBy(c => c).ToArray()));

            return sortedWords.GroupBy(x => x).All(g => g.Count() == 1);
        }
    }

    public class Day4Tests
    {
        [Fact]
        public void Day4_part1_test()
        {
            var lines = File.ReadAllLines(@"Day4\part1_test.txt");

            Day4.GetValidPassphrases_Part1(lines).Should().Be(3);
        }

        [Fact]
        public void Day4_part1_solution()
        {
            var lines = File.ReadAllLines(@"Day4\input.txt");

            Day4.GetValidPassphrases_Part1(lines).Should().Be(386);
        }

        [Fact]
        public void Day4_part2_test1()
        {
            Day4.IsLineValid("abcde fghij").Should().BeTrue();
        }

        [Fact]
        public void Day4_part2_test2()
        {
            Day4.IsLineValid("abcde xyz ecdab").Should().BeFalse();
        }

        [Fact]
        public void Day4_part2_test3()
        {
            Day4.IsLineValid("a ab abc abd abf abj").Should().BeTrue();
        }

        [Fact]
        public void Day4_part2_test4()
        {
            Day4.IsLineValid("iiii oiii ooii oooi oooo").Should().BeTrue();
        }

        [Fact]
        public void Day4_part2_test5()
        {
            Day4.IsLineValid("oiii ioii iioi iiio").Should().BeFalse();
        }

        [Fact]
        public void Day4_part2_solution()
        {
            var lines = File.ReadAllLines(@"Day4\input.txt");

            Day4.GetValidPassphrases_Part2(lines).Should().Be(208);
        }
    }
}