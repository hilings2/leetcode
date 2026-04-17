using System.Diagnostics;

public class Solution
{
    public int NumSpecialEquivGroups(string[] words)
    {
        HashSet<string> groups = new();
        foreach (string word in words)
        {
            int[] countEven = new int[26], countOdd = new int[26];
            for (int i = 0; i < word.Length; i++)
            {
                if (i % 2 == 0)
                {
                    countEven[word[i] - 'a']++;
                }
                else
                {
                    countOdd[word[i] - 'a']++;
                }
            }
            groups.Add(string.Join(",", countEven) + string.Join(",", countOdd));
        }
        return groups.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();
        string[] words =
        [
            "abcd", "cdab", "cbad", "xyzz", "zzxy", "zzyx"
        ];
        Debug.Assert(sol.NumSpecialEquivGroups(words) == 3);

        words =
        [
            "abc", "acb", "bac", "bca", "cab", "cba"
        ];
        Debug.Assert(sol.NumSpecialEquivGroups(words) == 3);
    }
}
