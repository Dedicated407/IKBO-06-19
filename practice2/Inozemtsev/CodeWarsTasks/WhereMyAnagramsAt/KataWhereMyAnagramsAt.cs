using System.Collections.Generic;
using System.Linq;

namespace WhereMyAnagramsAt
{
    public class KataWhereMyAnagramsAt
    {
        public static IEnumerable<string> FindAnagrams(string word, IEnumerable<string> words) =>
            word.GroupBy(x => x)
                .Aggregate(
                    words.Where(x => x.Length == word.Length),
                    (current, letters) =>
                    {
                        return current.Where(currentWord =>
                            currentWord.Count(letter => letter == letters.Key) == letters.Count());
                    }
                );
    }
}
