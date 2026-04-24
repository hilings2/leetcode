using System.Diagnostics;

public class Solution {
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        int[] count2 = new int[26]; // chars needed to cover all words in words2
        foreach (string w2 in words2)
        {
            int[] count = new int[26];
            foreach (char c in w2)
            {
                count[c-'a']++;
                count2[c-'a'] = Math.Max(count2[c-'a'], count[c-'a']);
            }            
        }
        List<string> res = [];
        foreach (string w1 in words1)
        {
            int[] count = new int[26];
            foreach (char c in w1)
            {
                count[c-'a']++;
            }
            bool isUniversal = true;
            for (int i = 0; i < 26; i++)
            {
                if (count[i] < count2[i])
                {
                    isUniversal = false;
                    break;
                }
            }
            if (isUniversal)
            {
                res.Add(w1);
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] words1 = ["amazon", "apple", "facebook", "google", "leetcode"];
        string[] words2 = ["e", "o"];
        Debug.Assert(sol.WordSubsets(words1, words2).OrderBy(x => x).SequenceEqual(new[] { "facebook", "google", "leetcode" }.OrderBy(x => x)));

        words1 = ["amazon", "apple", "facebook", "google", "leetcode"];
        words2 = ["lc", "eo"];
        Debug.Assert(sol.WordSubsets(words1, words2).SequenceEqual(new[] { "leetcode" }));

        words1 = ["acaac", "cccbb", "aacbb", "caacc", "bcbbb"];
        words2 = ["c", "cc", "b"];
        Debug.Assert(sol.WordSubsets(words1, words2).SequenceEqual(new[] { "cccbb" }));

        Console.WriteLine("passed");
    }
}
