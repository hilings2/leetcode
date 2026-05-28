using System.Diagnostics;

public class Solution {
    private static readonly int mod = 1_000_000_007;
    public int DistinctSubseqII(string s) {
        long[] endsWith = new long[26];
        foreach (char c in s)
        {
            endsWith[c-'a'] = endsWith.Sum() % mod + 1;
        }
        return (int)(endsWith.Sum() % mod);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "abc";
        Debug.Assert(sol.DistinctSubseqII(s) == 7);

        s = "aba";
        Debug.Assert(sol.DistinctSubseqII(s) == 6);

        s = "aaa";
        Debug.Assert(sol.DistinctSubseqII(s) == 3);

        Console.WriteLine("passed");
    }
}
