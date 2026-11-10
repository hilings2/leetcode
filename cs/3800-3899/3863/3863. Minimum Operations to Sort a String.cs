using System.Diagnostics;

public class Solution {
    public int MinOperations(string s) {
        bool isSorted = true;
        char min = s[0], max = s[0];
        for (int i = 1; i < s.Length; i++) {
            if (s[i] < min) min = s[i];
            if (s[i] > max) max = s[i];
            if (s[i - 1] > s[i]) isSorted = false;
        }
        if (isSorted) return 0;
        if (s.Length == 2) return -1;
        if (s[0] == min || s[^1] == max) return 1;
        for (int i = 1; i < s.Length - 1; i++) {
            if (s[i] == min || s[i] == max)
                return 2;
        }
        return 3;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "dog";
        Debug.Assert(sol.MinOperations(s) == 1);

        s = "card";
        Debug.Assert(sol.MinOperations(s) == 2);

        s = "gf";
        Debug.Assert(sol.MinOperations(s) == -1);

        Console.WriteLine("passed");
    }
}
