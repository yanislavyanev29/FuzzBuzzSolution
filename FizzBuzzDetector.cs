
using System.Text;

namespace FizzBuzz
{
   
    public class FizzBuzzDetector
    {

        public FizzBuzzResult GetOverlappings(string input)
        {
            /// The processed output string with Fizz/Buzz/FizzBuzz replacements.
            /// If the input is not correct throw an exception 
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input.Length < 7 || input.Length > 100)
                throw new ArgumentException("Input length must be between 7 and 100 characters.", nameof(input));
            //Add two StringBuilders which contains the result string and current word
            StringBuilder result = new StringBuilder();
            StringBuilder word = new StringBuilder();

            int wordCnt = 0, cnt = 0;
            for (int i = 0; i < input.Length;)
            {
                //chech if the current inputp[i] is letter or part of word and if it is go in while loop till the word is ended
                if (IsLetterOrDigit(input[i]) || input[i] == '\'')
                {
                    word.Clear();

                    while (i < input.Length && (IsLetterOrDigit(input[i]) || input[i] == '\''))
                    {
                        word.Append(input[i]);
                        i++;
                    }

                    wordCnt++;
                    string replacement = word.ToString();
                    bool isFizz = wordCnt % 3 == 0;
                    bool isBuzz = wordCnt % 5 == 0;
                    //if it is 15th word replace with FizzBuzz
                    if (isFizz && isBuzz)
                    {
                        replacement = "FizzBuzz";
                        cnt++;
                    }
                    //if is third word replace with Fizz
                    else if (isFizz)
                    {
                        replacement = "Fizz";
                        cnt++;
                    }
                    //if it is fifth word replace with Buzz
                    else if (isBuzz)
                    {
                        replacement = "Buzz";
                        cnt++;
                    }

                    result.Append(replacement);
                }
                else
                {
                    result.Append(input[i]);
                    i++;
                }


            }
            //return the final result
            return new FizzBuzzResult
            {
                Output = result.ToString(),
                Count = cnt
            };
        }
        //Helper function
        private static bool IsLetterOrDigit(char c)
        {
            return (c >= 'A' && c <= 'Z') ||
             (c >= 'a' && c <= 'z') ||
             (c >= '0' && c <= '9');
        }
    }
}
