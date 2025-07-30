using Xunit;
using FizzBuzz;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void ThirdSixthNinthAreFizz_AndFifthIsBuzz()
        {
            var detector = new FizzBuzzDetector();
            string input = "a b c d e f g h i";
            var result = detector.GetOverlappings(input);

            Assert.Equal(4, result.Count); // Fizz x3, Buzz x1
            Assert.Contains("Fizz", result.Output);
            Assert.Contains("Buzz", result.Output);
        }
        [Fact]
        public void FifthWordIsBuzz()
        {
            var detector = new FizzBuzzDetector();
            string input = "one two three four five";
            var result = detector.GetOverlappings(input);

            Assert.Contains("Buzz", result.Output);
            Assert.Equal(2, result.Count); // Fizz на 3, Buzz на 5
        }

        [Fact]
        public void SymbolsOnlyReturnsZeroMatches()
        {
            var detector = new FizzBuzzDetector();
            string input = "!@#$%^&*()_+";
            var result = detector.GetOverlappings(input);

            Assert.Equal(0, result.Count);
            Assert.Equal(input, result.Output); // нищо не се сменя
        }

        [Fact]
        public void InputExactlyAtLimit_100Characters()
        {
            var detector = new FizzBuzzDetector();
            string input = string.Join(" ", Enumerable.Repeat("word", 20)); // "word word word..." (20 x 5 = 100 chars)
            var result = detector.GetOverlappings(input);

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void ThrowsOnShortInput()
        {
            var detector = new FizzBuzzDetector();
            Assert.Throws<ArgumentException>(() => detector.GetOverlappings("short"));
        }
    }
}
