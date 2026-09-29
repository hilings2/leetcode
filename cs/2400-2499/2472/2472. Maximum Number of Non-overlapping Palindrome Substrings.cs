using System.Diagnostics;

public class Solution {
    public int MaxPalindromes(string s, int k) {
        int res = 0;
        for (int nextStart = 0, end = k - 1; end < s.Length; end++) {
            int start = end - k + 1;
            if (start >= nextStart && IsPalindrome(s, start, end)
             || (start-1 >= nextStart && IsPalindrome(s, start-1, end))) {
                res++;
                nextStart = end + 1;
                end += k - 1;
            }
        }
        return res;
    }

    private static bool IsPalindrome(string s, int start, int end) {
        for (; start < end; start++, end--) {
            if (s[start] != s[end]) return false;
        }
        return true;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "abaccdbbd";
        int k = 3;
        Debug.Assert(sol.MaxPalindromes(s, k) == 2);

        s = "adbcda";
        k = 2;
        Debug.Assert(sol.MaxPalindromes(s, k) == 0);

        Console.WriteLine("passed");
    }
}