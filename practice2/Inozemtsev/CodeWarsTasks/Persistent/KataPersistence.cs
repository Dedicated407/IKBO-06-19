using System;
using System.Linq;

namespace Persistent
{
    public class KataPersistence
    {
        public static int GetPersistence(long digit)
        {
            var operationsCount = 0;
            while (digit.ToString().Length != 1)
            {
                digit = digit.ToString().Select(x => Convert.ToInt32(x.ToString())).ToList().Aggregate((x, y) => x * y);
                operationsCount++;
            }

            return operationsCount;
        }
    }
}
