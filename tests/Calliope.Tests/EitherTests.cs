using Calliope.Monads;
using Xunit;

namespace Calliope.Tests
{
    public class EitherTests
    {
        [Fact]
        public void MatchLeftOptional_correctly_applies_logic_to_left()
        {
            var either = new LeftOrRight(new Left("Frodo"));
            var result = either.MatchLeftOptional(x => x.Name);

            Assert.Equal(new Some<string>("Frodo"), result);
        }
        
        [Fact]
        public void MatchLeftOptional_correctly_returns_none_when_right_is_defined()
        {
            var either = new LeftOrRight(new Right(4));
            var result = either.MatchLeftOptional(x => x.Name);

            Assert.Equal(new None<string>(), result);
        }
        
        [Fact]
        public void MatchOptional_correctly_applies_logic_to_right()
        {
            var either = new LeftOrRight(new Right(4));
            var result = either.MatchRightOptional(x => x.Number * 2);

            Assert.Equal(new Some<int>(8), result);
        }
        
        [Fact]
        public void MatchRightOptional_correctly_returns_none_when_left_is_defined()
        {
            var either = new LeftOrRight(new Left("Samwise"));
            var result = either.MatchRightOptional(x => x.Number);

            Assert.Equal(new None<int>(), result);
        }

        private class Left
        {
            public string Name { get; }

            internal Left(string name)
            {
                Name = name;
            }
        }

        private class Right
        {
            public int Number { get; }

            internal Right(int number)
            {
                Number = number;
            }
        }

        private class LeftOrRight : Either<Left, Right>
        {
            public LeftOrRight(Left left) : base(left) { }
            public LeftOrRight(Right right) : base(right) { }
        }
    }
}