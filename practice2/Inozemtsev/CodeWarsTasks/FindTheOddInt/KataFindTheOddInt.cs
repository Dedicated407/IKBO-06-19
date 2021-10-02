using System.Collections.Generic;
using System.Linq;

namespace FindTheOddInt
{
    public class KataFindTheOddInt
    {
        public static int FindIt(IEnumerable<int> sequence) =>
            sequence.GroupBy(x => x)
                .First(x => x.Count() % 2 != 0)
                .Key;
    }
}
