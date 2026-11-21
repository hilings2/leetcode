using System.Diagnostics;

public class Solution {
    public int ClimbStairs(int n, int[] costs) {
        int[] dp = new int[n + 1];
        dp[0] = 0;
        for (int i = 1; i <= n; i++) {
            dp[i] = dp[i - 1] + costs[i - 1] + 1;
            if (i >= 2) {
                dp[i] = Math.Min(dp[i], dp[i - 2] + costs[i - 1] + 4);
            }
            if (i >= 3) {
                dp[i] = Math.Min(dp[i], dp[i - 3] + costs[i - 1] + 9);
            }
        }
        return dp[n];
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 4;
        int[] costs = [1, 2, 3, 4];
        Debug.Assert(sol.ClimbStairs(n, costs) == 13);

        n = 4;
        costs = [5, 1, 6, 2];
        Debug.Assert(sol.ClimbStairs(n, costs) == 11);

        n = 3;
        costs = [9, 8, 3];
        Debug.Assert(sol.ClimbStairs(n, costs) == 12);

        Console.WriteLine("passed");
    }
}
