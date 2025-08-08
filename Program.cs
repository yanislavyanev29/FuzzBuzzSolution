using FizzBuzz;

var detector = new FizzBuzzDetector();
string input = @"Mary had a little lamb Little lamb,little lamb Mary had a little lamb It's fleece was white as snow";
var result = detector.GetOverlappings(input);
Console.WriteLine(result.Output);
Console.WriteLine($"Count: {result.Count}");