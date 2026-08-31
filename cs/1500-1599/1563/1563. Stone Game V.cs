using System.Diagnostics;

public class Solution {
    public int StoneGameV(int[] stoneValue) {
        int n = stoneValue.Length;
        int[] prefixSum = new int[n + 1];
        for (int i = 0; i < n; i++) {
            prefixSum[i + 1] = prefixSum[i] + stoneValue[i];
        }
        int[,] dp = new int[n, n];
        for (int len = 2; len <= n; len++) {
            for (int left = 0; left + len <= n; left++) {
                int right = left + len - 1;
                for (int mid = left; mid < right; mid++) {
                    int leftSum = prefixSum[mid + 1] - prefixSum[left];
                    int rightSum = prefixSum[right + 1] - prefixSum[mid + 1];
                    if (leftSum < rightSum) {
                        dp[left, right] = Math.Max(dp[left, right], leftSum + dp[left, mid]);
                    } else if (leftSum > rightSum) {
                        dp[left, right] = Math.Max(dp[left, right], rightSum + dp[mid + 1, right]);
                    } else {
                        dp[left, right] = Math.Max(dp[left, right], leftSum + Math.Max(dp[left, mid], dp[mid + 1, right]));
                    }
                }
            }
        }
        return dp[0, n - 1];
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] stoneValue = [6, 2, 3, 4, 5, 5];
        Debug.Assert(sol.StoneGameV(stoneValue) == 18);

        stoneValue = [7, 7, 7, 7, 7, 7, 7];
        Debug.Assert(sol.StoneGameV(stoneValue) == 28);

        stoneValue = [4];
        Debug.Assert(sol.StoneGameV(stoneValue) == 0);

        Console.WriteLine("passed");
    }
}