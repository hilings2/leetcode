using System.Diagnostics;

public class Solution {
    public int MinimumPushes(string word) {
        int n = word.Length, q = n / 8, r = n % 8;
        return 8 * q * (q + 1) / 2 + r * (q + 1);
    }

    public int MinimumPushes0(string word) {
        int res = 0;
        for (int i = 0; i < word.Length; i++) {
            res += i / 8 + 1;
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string word = "abcde";
        Debug.Assert(sol.MinimumPushes(word) == 5);

        word = "xycdefghij";
        Debug.Assert(sol.MinimumPushes(word) == 12);

        Console.WriteLine("passed");
    }
}
