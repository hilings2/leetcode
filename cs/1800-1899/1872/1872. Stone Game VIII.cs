using System.Diagnostics;

public class Solution {
    public int StoneGameVIII(int[] stones) {
        int n = stones.Length;
        int[] prefixSum = new int[n];
        for (int i = 0; i < n; i++) {
            prefixSum[i] = stones[i] + (i > 0 ? prefixSum[i - 1] : 0);
        }
        int best = prefixSum[n - 1];
        for (int i = n - 3; i >= 0; i--) {
            best = Math.Max(best, prefixSum[i + 1] - best);            
        }
        return best;
    }

    public int StoneGameVIII0(int[] stones) {
        int n = stones.Length;
        int[] prefixSum = new int[n];
        for (int i = 0; i < n; i++) {
            prefixSum[i] = stones[i] + (i > 0 ? prefixSum[i - 1] : 0);
        }
        int[] dp = new int[n]; // dp[i] = best of (prefixSum[j] - dp[j]) for j in [i, n-1]
        dp[n - 2] = prefixSum[n - 1]; // base case
        for (int i = n - 3; i >= 0; i--) {
            // dp[i+1] is actually best of (prefixSum[j] - dp[j]) for j in [i+1, n-1]
            dp[i] = Math.Max(prefixSum[i + 1] - dp[i + 1], dp[i + 1]);
        }
        return dp[0];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] stones = [-1, 2, -3, 4, -5];
        Debug.Assert(sol.StoneGameVIII(stones) == 5);

        stones = [7, -6, 5, 10, 5, -2, -6];
        Debug.Assert(sol.StoneGameVIII(stones) == 13);

        stones = [-10, -12];
        Debug.Assert(sol.StoneGameVIII(stones) == -22);

        Console.WriteLine("passed");
    }
}