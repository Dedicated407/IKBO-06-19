using System;
using System.Linq;

namespace BitsCount
{
    public class KataBitsCount
    {
        public static int CountBits(int digit) =>
            Convert.ToString(digit, 2)
                .Count(x => x == '1');
    }
}
