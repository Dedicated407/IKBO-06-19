using System.Collections.Generic;
using System.Linq;

namespace CategorizeNewMember
{
    public class KataCategorizeNewMember
    {
        public static IEnumerable<string> GetOpenOrSenior(IEnumerable<int[]> data) =>
            data.Select(person => person[0] >= 55 && person[1] > 7  
                ? "Senior"
                : "Open");
    }
}
