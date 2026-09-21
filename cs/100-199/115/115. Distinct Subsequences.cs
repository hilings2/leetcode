using System.Diagnostics;

public class Solution {
    public int NumDistinct(string s, string t) {
        int n = s.Length, m = t.Length;
        int[,] dp = new int[n + 1, m + 1]; // d[i,j]: how many ways for s[0..i-1] to match t[0..j-1]
        for (int i = 0; i <= n; i++) {
            dp[i, 0] = 1;
        }
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m && j <= i; j++) {
                dp[i, j] = s[i - 1] == t[j - 1]
                    ? dp[i - 1, j - 1] + dp[i - 1, j] // use s[i-1] to match t[j-1], or don't use
                    : dp[i - 1, j];
            }
        }
        return dp[n, m];
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "rabbbit";
        string t = "rabbit";
        Debug.Assert(sol.NumDistinct(s, t) == 3);

        s = "babgbag";
        t = "bag";
        Debug.Assert(sol.NumDistinct(s, t) == 5);

        Console.WriteLine("passed");
    }
}