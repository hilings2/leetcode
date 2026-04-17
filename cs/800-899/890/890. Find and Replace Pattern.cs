using System.Diagnostics;

public class Solution
{
    public IList<string> FindAndReplacePattern(string[] words, string pattern)
    {
        List<string> r = new();
        foreach (string word in words)
        {
            Dictionary<char, char> mapChar = new();
            HashSet<char> setChar = new();
            bool match = true;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i], p = pattern[i];
                if (mapChar.ContainsKey(c))
                {
                    if (mapChar[c] != p)
                    {
                        match = false;
                        break;
                    }
                }
                else if (setChar.Contains(p))
                {
                    match = false;
                    break;
                }
                else
                {
                    mapChar[c] = p;
                    setChar.Add(p);
                }
            }
            if (match)
            {
                r.Add(word);
            }
        }
        return r;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();
        string[] words = ["abc", "deq", "mee", "aqq", "dkd", "ccc"];
        string pattern = "abb";
        Debug.Assert(sol.FindAndReplacePattern(words, pattern).SequenceEqual(new[] { "mee", "aqq" }));

        words = ["a", "b", "c"];
        pattern = "a";
        Debug.Assert(sol.FindAndReplacePattern(words, pattern).SequenceEqual(new[] { "a", "b", "c" }));
    }
}
