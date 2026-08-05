using System.Diagnostics;

public class Solution {
    public bool SplitArraySameAverage(int[] nums) {
        int n = nums.Length, maxK = nums.Length / 2, S = nums.Sum();
        HashSet<int>[] dp = new HashSet<int>[maxK + 1];
        for (int i = 0; i <= maxK; i++) dp[i] = [];
        dp[0].Add(0);
        foreach (int a in nums) {
            for (int k = maxK; k >= 1; k--) {
                foreach (int s in dp[k - 1]) {
                    dp[k].Add(s + a);   // all possible sums of k elements
                }
            }
        }
        for (int k = 1; k <= maxK; k++) {
            if (S * k % n != 0) continue;
            if (dp[k].Contains(k * S / n)) return true;
        }
        return false;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 3, 4, 5, 6, 7, 8];
        Debug.Assert(sol.SplitArraySameAverage(nums) == true);

        nums = [3, 1];
        Debug.Assert(sol.SplitArraySameAverage(nums) == false);

        Console.WriteLine("passed");
    }
}
