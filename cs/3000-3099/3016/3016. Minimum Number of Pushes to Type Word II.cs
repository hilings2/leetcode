using System.Diagnostics;

public class Solution {
    public int MinimumPushes(string word) {
        int[] freq = new int[26];
        foreach (char c in word) freq[c - 'a']++;
        Array.Sort(freq);
        int res = 0;
        for (int i = 0; i < 26; i++) res += freq[25 - i] * (i / 8 + 1);
        return res;
    }
    
    public int MinimumPushes2(string word)
    {
        return word.GroupBy(c => c)
            .Select(g => g.Count()) // frequency of each character
            .OrderByDescending(c => c)
            .Select((count, index) => count * (index / 8 + 1)) // 
            .Sum();
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string word = "abcde";
        Debug.Assert(sol.MinimumPushes(word) == 5);

        word = "xyzxyzxyzxyz";
        Debug.Assert(sol.MinimumPushes(word) == 12);

        word = "aabbccddeeffgghhiiiiii";
        Debug.Assert(sol.MinimumPushes(word) == 24);

        Console.WriteLine("passed");
    }
}