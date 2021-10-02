using System.Collections.Generic;
using System.Linq;

namespace TribonacciSequence
{
    public class KataTribonacciSequence
    {
        public static IEnumerable<double> GetTribonacci(double[] array, int n)
        {
            if (n < 4)
            {
                var result = array.Take(n);
                foreach (var digit in result)
                {
                    yield return digit;
                }
            }
            else
            {
                var (digit1, digit2, digit3) = (array[0], array[1], array[2]);

                yield return digit1;
                yield return digit2;
                yield return digit3;
                for (var i = 0; i < n - 3; i++)
                {
                    var currentDigit = digit1 + digit2 + digit3;
                    (digit1, digit2, digit3) = (digit2, digit3, currentDigit);

                    yield return currentDigit;
                }
            }
        }
    }
}
