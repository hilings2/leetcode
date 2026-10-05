using System.Diagnostics;

public class Solution {
    public long[] ResultArray(int[] nums, int k) {
        long[] dp = new long[k];
        long[] res = new long[k];
        foreach (int num in nums) {
            long[] next = new long[k];
            int remainder = num % k;
            next[remainder]++; // the subarray consisting of only nums[i]

            for (int r = 0; r < k; r++) {
                int newRemainder = r * remainder % k; // existing subarrays extended by nums[i]
                next[newRemainder] += dp[r];
            }
            for (int r = 0; r < k; r++) {
                res[r] += next[r];
            }
            dp = next;
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 3, 4, 5];
        int k = 3;
        long[] expected = [9, 2, 4];
        Debug.Assert(sol.ResultArray(nums, k).SequenceEqual(expected));

        nums = [1, 2, 4, 8, 16, 32];
        k = 4;
        expected = [18, 1, 2, 0];
        Debug.Assert(sol.ResultArray(nums, k).SequenceEqual(expected));

        nums = [1, 1, 2, 1, 1];
        k = 2;
        expected = [9, 6];
        Debug.Assert(sol.ResultArray(nums, k).SequenceEqual(expected));

        Console.WriteLine("passed");
    }
}
