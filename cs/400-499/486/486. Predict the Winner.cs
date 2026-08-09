using System.Diagnostics;

public class Solution {
    public bool PredictTheWinner(int[] nums) {
        int n = nums.Length;
        int[] dp = new int[n];
        for (int i = n - 1; i >= 0; i--) {
            dp[i] = nums[i];
            for (int j = i + 1; j < n; j++) {
                dp[j] = Math.Max(nums[i] - dp[j], nums[j] - dp[j - 1]);
            }
        }
        return dp[n - 1] >= 0;
    }

    public bool PredictTheWinner0(int[] nums) {
        int n = nums.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++) dp[i] = new int[n];
        for (int i = n - 1; i >= 0; i--) {
            dp[i][i] = nums[i];
            for (int j = i + 1; j < n; j++) {
                dp[i][j] = Math.Max(nums[i] - dp[i + 1][j], nums[j] - dp[i][j - 1]);
            }
        }
        return dp[0][n - 1] >= 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] nums = [1, 5, 2];
        Debug.Assert(sol.PredictTheWinner(nums) == false);

        nums = [1, 5, 233, 7];
        Debug.Assert(sol.PredictTheWinner(nums) == true);

        Console.WriteLine("passed");
    }
}