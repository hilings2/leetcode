using System.Diagnostics;

public class Solution {
    public int NumOfStrings(string[] patterns, string word) {
        int res = 0;
        foreach (string pattern in patterns) {
            if (word.Contains(pattern)) {
                res++;
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] patterns = ["a", "abc", "bc", "d"];
        string word = "abc";
        Debug.Assert(sol.NumOfStrings(patterns, word) == 3);

        patterns = ["a", "b", "c"];
        word = "aaaaabbbbb";
        Debug.Assert(sol.NumOfStrings(patterns, word) == 2);

        patterns = ["a", "a", "a"];
        word = "ab";
        Debug.Assert(sol.NumOfStrings(patterns, word) == 3);

        Console.WriteLine("passed");
    }
}
