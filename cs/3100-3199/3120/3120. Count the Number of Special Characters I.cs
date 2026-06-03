using System.Diagnostics;

public class Solution {
    public int NumberOfSpecialChars(string word) {
        bool[] counts = new bool[52];   // 0-25 for uppercase, 26-51 for lowercase
        foreach (char c in word)
        {
            counts[char.IsUpper(c) ? c - 'A' : c - 'a' + 26] = true;
        }
        int res = 0;
        for (int i = 0; i < 26; i++)
        {
            if (counts[i] && counts[i + 26])
            {
                res++;
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string word = "aaAbcBC";
        Debug.Assert(sol.NumberOfSpecialChars(word) == 3);

        word = "abc";
        Debug.Assert(sol.NumberOfSpecialChars(word) == 0);

        word = "abBCab";
        Debug.Assert(sol.NumberOfSpecialChars(word) == 1);

        Console.WriteLine("passed");
    }
}
