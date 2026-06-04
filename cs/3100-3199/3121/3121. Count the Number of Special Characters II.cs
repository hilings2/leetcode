using System.Diagnostics;

public class Solution {
    public int NumberOfSpecialChars(string word) {
        int[] states = new int[26];
        // state 0: no upper or lower
        // state 1: has lower
        // state 2: all lower before upper
        // state 3: lower after upper or no lower before upper
        foreach (char c in word)
        {
            if (char.IsLower(c))
            {
                int idx = c - 'a';
                switch (states[idx])
                {
                    case 0:
                        states[idx] = 1;
                        break;
                    case 2:
                        states[idx] = 3;
                        break;
                }
            }
            else
            {
                int idx = c - 'A';
                switch (states[idx])
                {
                    case 0:
                        states[idx] = 3;
                        break;
                    case 1:
                        states[idx] = 2;
                        break;
                }
            }
        }
        int res = 0;
        foreach (int state in states)
        {
            if (state == 2)
                res++;
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

        word = "AbBCab";
        Debug.Assert(sol.NumberOfSpecialChars(word) == 0);

        Console.WriteLine("passed");
    }
}
