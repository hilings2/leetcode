using System.Diagnostics;

public class Solution
{
    public string[] UncommonFromSentences(string s1, string s2)
    {
        Dictionary<string, int> dict1 = new(), dict2 = new();
        s1.Split(' ').ToList().ForEach(word => dict1[word] = dict1.ContainsKey(word) ? dict1[word] + 1 : 1);
        s2.Split(' ').ToList().ForEach(word => dict2[word] = dict2.ContainsKey(word) ? dict2[word] + 1 : 1);

        List<string> words = new();
        foreach (KeyValuePair<string, int> wordCount in dict1)
        {
            if (wordCount.Value == 1 && !dict2.ContainsKey(wordCount.Key))
            {
                words.Add(wordCount.Key);
            }
        }
        foreach (KeyValuePair<string, int> wordCount in dict2)
        {
            if (wordCount.Value == 1 && !dict1.ContainsKey(wordCount.Key))
            {
                words.Add(wordCount.Key);
            }
        }
        return words.ToArray();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        string s1 = "this apple is sweet";
        string s2 = "this apple is sour";
        Debug.Assert(sol.UncommonFromSentences(s1, s2).SequenceEqual(new[] { "sweet", "sour" }));

        s1 = "apple apple";
        s2 = "banana";
        Debug.Assert(sol.UncommonFromSentences(s1, s2).SequenceEqual(new[] { "banana" }));
    }
}
