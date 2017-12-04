using System;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2017.Day3
{
    public class Day3
    {
        public static Position CreateSpiral(int number)
        {
            var position = new Position();

            int steps = number - 1;
            int targetDistance = 1;
            int distanceInDirection = 0;
            var direction = Direction.Right;
            bool shouldIncreaseDistance = false;

            for (int i = 1; i <= steps; i++)
            {
                if (direction == Direction.Right)
                {
                    position.X++;
                }
                else if (direction == Direction.Up)
                {
                    position.Y++;
                }
                else if (direction == Direction.Left)
                {
                    position.X--;
                }
                else // down
                {
                    position.Y--;
                }

                distanceInDirection++;

                if (distanceInDirection == targetDistance)
                {
                    direction = GetNextDirection(direction);
                    distanceInDirection = 0;

                    if (shouldIncreaseDistance)
                    {
                        targetDistance++;
                    }

                    shouldIncreaseDistance = !shouldIncreaseDistance;
                }
            }

            return position;
        }

        private enum Direction
        {
            Right,
            Up,
            Left,
            Down
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
        public void Solution_for_number_02()
        {
            Position p = Day3.CreateSpiral(2);
            p.X.Should().Be(1, "X");
            p.Y.Should().Be(0, "Y");
            p.DistanceToCenter.Should().Be(1);
        }

        [Fact]
        public void Solution_for_number_03()
        {
            Position p = Day3.CreateSpiral(3);
            p.X.Should().Be(1, "X");
            p.Y.Should().Be(1, "Y");
            p.DistanceToCenter.Should().Be(2);
        }

        [Fact]
        public void Solution_for_number_04()
        {
            Position p = Day3.CreateSpiral(4);
            p.X.Should().Be(0);
            p.Y.Should().Be(1);
            p.DistanceToCenter.Should().Be(1);
        }

        [Fact]
        public void Solution_for_number_05()
        {
            Position p = Day3.CreateSpiral(5);
            p.X.Should().Be(-1);
            p.Y.Should().Be(1);
            p.DistanceToCenter.Should().Be(2);
        }

        [Fact]
        public void Solution_for_number_06()
        {
            Position p = Day3.CreateSpiral(6);
            p.X.Should().Be(-1, "X");
            p.Y.Should().Be(0, "Y");
            p.DistanceToCenter.Should().Be(1);
        }

        [Fact]
        public void Solution_for_number_07()
        {
            Position p = Day3.CreateSpiral(7);
            p.X.Should().Be(-1);
            p.Y.Should().Be(-1);
            p.DistanceToCenter.Should().Be(2);
        }

        [Fact]
        public void Solution_for_number_08()
        {
            Position p = Day3.CreateSpiral(8);
            p.X.Should().Be(0, "X");
            p.Y.Should().Be(-1, "Y");
            p.DistanceToCenter.Should().Be(1);
        }

        [Fact]
        public void Solution_for_number_10()
        {
            Position p = Day3.CreateSpiral(10);
            p.X.Should().Be(2, "X");
            p.Y.Should().Be(-1, "Y");
            p.DistanceToCenter.Should().Be(3);
        }

        [Fact]
        public void Solution_for_number_17()
        {
            Position p = Day3.CreateSpiral(17);
            p.X.Should().Be(-2);
            p.Y.Should().Be(2);
            p.DistanceToCenter.Should().Be(4);
        }

        [Fact]
        public void Solution_for_number_22()
        {
            Position p = Day3.CreateSpiral(22);
            p.X.Should().Be(-1);
            p.Y.Should().Be(-2);
            p.DistanceToCenter.Should().Be(3);
        }
        
        [Fact]
        public void Position_for_number_347991()
        {
            Position p = Day3.CreateSpiral(347991);
            p.X.Should().Be(-185);
            p.Y.Should().Be(295);
            p.DistanceToCenter.Should().Be(480);
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int DistanceToCenter => Math.Abs(X) + Math.Abs(Y);
    }
}