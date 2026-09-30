using System.Diagnostics;

public class Solution {
    private static readonly int MOD = 1000000007;
    public int NumberOfSets(int n, int k) {
        int[,] dp = new int[n + 1, k + 1];
        for (int i = 0; i <= n; i++) {
            dp[i, 0] = 1; // 0 segment, only 1 way
        }
        for (int j = 1; j <= k; j++) {
            dp[1, j] = 0; // 1 point, cannot form segment
        }
        for (int j = 1; j <= k; j++) {
            int total = 0;
            for (int i = 2; i <= n; i++) {
                // total = sum of dp[x, j-1] for x in [1, i-1],
                // appending like this avoid recomputing the sum from scratch each time
                total = (total + dp[i - 1, j - 1]) % MOD;
                dp[i, j] = (dp[i - 1, j] + total) % MOD;
            }
        }
        return dp[n, k];
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 4;
        int k = 2;
        Debug.Assert(sol.NumberOfSets(n, k) == 5);

        n = 3;
        k = 1;
        Debug.Assert(sol.NumberOfSets(n, k) == 3);

        n = 30;
        k = 7;
        Debug.Assert(sol.NumberOfSets(n, k) == 796297179);

        Console.WriteLine("passed");
    }
}