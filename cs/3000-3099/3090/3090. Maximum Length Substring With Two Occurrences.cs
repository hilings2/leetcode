using System.Diagnostics;

public class Solution {
    public int MaximumLengthSubstring(string s) {
        int[] counts = new int[26];
        int res = 0;
        for (int i = 0, j = 0; j < s.Length; j++) {
            int index = s[j] - 'a';
            counts[index]++;
            for (; counts[index] > 2; i++) {
                counts[s[i] - 'a']--;
            }
            res = Math.Max(res, j - i + 1);
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "bcbbbcba";
        Debug.Assert(sol.MaximumLengthSubstring(s) == 4);

        s = "aaaa";
        Debug.Assert(sol.MaximumLengthSubstring(s) == 2);

        Console.WriteLine("passed");
    }
}