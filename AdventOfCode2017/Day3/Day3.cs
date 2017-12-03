using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2017.Day3
{
    public class Day3
    {
        public static int GetStepsForNumber(int number)
        {
            return 0;
        }

        private enum Direction
        {
            Right,
            Up,
            Left,
            Down
        }

        public static Position CreateSpiral(int number)
        {
            Position pos = new Position();
            int walkingDistance = 1;
            int distanceWalkedInDirection = 0;
            var direction = Direction.Right;
            bool shouldIncreaseDistance = false;

            for (int i = 1; i <= number; i++)
            {
                if (direction == Direction.Right)
                {
                    pos.X++;
                }
                else if (direction == Direction.Up)
                {
                    pos.Y++;
                }
                else if (direction == Direction.Left)
                {
                    pos.X--;
                }
                else // down
                {
                    pos.Y--;
                }

                distanceWalkedInDirection++;


                if (distanceWalkedInDirection == walkingDistance)
                {
                    distanceWalkedInDirection = 0;
                    direction = GetNextDirection(direction);

                    if (shouldIncreaseDistance)
                    {
                        walkingDistance++;
                    }

                    shouldIncreaseDistance = !shouldIncreaseDistance;
                }

                pos.Number = i;
            }

            return pos;
        }

        private static Direction GetNextDirection(Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.Right:
                    return Direction.Up;
                case Direction.Up:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Right;
            }

            throw new Exception("Invalid direction");
        }
    }

    public class Day3Tests
    {
        [Fact]
        public void Position_for_01_step()
        {
            Position p = Day3.CreateSpiral(1);
            //p.Number.Should().Be(2);
            p.X.Should().Be(1, "X");
            p.Y.Should().Be(0, "Y");
        }

        [Fact]
        public void Position_for_02_steps()
        {
            Position p = Day3.CreateSpiral(2);
            //p.Number.Should().Be(2);
            p.X.Should().Be(1, "X");
            p.Y.Should().Be(1, "Y");
        }

        [Fact]
        public void Position_for_03_steps()
        {
            Position p = Day3.CreateSpiral(3);
            //p.Number.Should().Be(3);
            p.X.Should().Be(0);
            p.Y.Should().Be(1);
        }

        [Fact]
        public void Position_for_04_steps()
        {
            Position p = Day3.CreateSpiral(4);
            //p.Number.Should().Be(4);
            p.X.Should().Be(-1);
            p.Y.Should().Be(1);
        }

        [Fact]
        public void Position_for_05_steps()
        {
            Position p = Day3.CreateSpiral(5);
            //p.Number.Should().Be(5);
            p.X.Should().Be(-1, "X");
            p.Y.Should().Be(0, "Y");
        }

        [Fact]
        public void Position_for_06_steps()
        {
            Position p = Day3.CreateSpiral(6);
            //p.Number.Should().Be(5);
            p.X.Should().Be(-1);
            p.Y.Should().Be(-1);
        }

        [Fact]
        public void Position_for_07_steps()
        {
            Position p = Day3.CreateSpiral(7);
            //p.Number.Should().Be(5);
            p.X.Should().Be(0, "X");
            p.Y.Should().Be(-1, "Y");
        }

        [Fact]
        public void Position_for_10_steps()
        {
            Position p = Day3.CreateSpiral(10);
            //p.Number.Should().Be(10);
            p.X.Should().Be(2, "X");
            p.Y.Should().Be(0, "Y");
        }

        [Fact]
        public void Position_for_17_steps()
        {
            Position p = Day3.CreateSpiral(17);
            //p.Number.Should().Be(17);
            p.X.Should().Be(-2);
            p.Y.Should().Be(1);
        }

        [Fact]
        public void Position_for_22_steps()
        {
            Position p = Day3.CreateSpiral(22);
            p.Number.Should().Be(22);
            p.X.Should().Be(0);
            p.Y.Should().Be(-2);
        }

        [Fact]
        public void Position_for_number_347991()
        {
            Position p = Day3.CreateSpiral(347990);
            p.Number.Should().Be(26);
            p.X.Should().Be(-185);
            p.Y.Should().Be(295);
        }

        [Fact]
        public void Square_1_needs_0_steps()
        {
            Day3.GetStepsForNumber(1).Should().Be(0);
        }

        [Fact]
        public void Square_2_needs_1_step()
        {
            Day3.GetStepsForNumber(2).Should().Be(1);
        }

        [Fact]
        public void Square_3_needs_2_steps()
        {
            Day3.GetStepsForNumber(3).Should().Be(2);
        }

        [Fact]
        public void Square_12_needs_3_steps()
        {
            Day3.GetStepsForNumber(12).Should().Be(3);
        }

        [Fact]
        public void Square_23_needs_2_steps()
        {
            Day3.GetStepsForNumber(23).Should().Be(2);
        }

        [Fact]
        public void Square_1024_needs_31_steps()
        {
            Day3.GetStepsForNumber(1024).Should().Be(31);
        }
    }

    public class Position
    {
        public int Number { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}