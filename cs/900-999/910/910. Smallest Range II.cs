using System.Diagnostics;

public class Solution {
    public int SmallestRangeII(int[] nums, int k) {
        Array.Sort(nums);
        int score = nums[^1] - nums[0];
        int max1 = nums[^1] - k, min1 = nums[0] + k;
        for (int i = 0 ; i < nums.Length-1; i++)
        {
            int max2 = Math.Max(max1, nums[i] + k);
            int min2 = Math.Min(min1, nums[i+1] - k);
            score = Math.Min(score, max2 - min2);
        }
        return score;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1];
        Debug.Assert(sol.SmallestRangeII(nums, 0) == 0);

        nums = [0, 10];
        Debug.Assert(sol.SmallestRangeII(nums, 2) == 6);

        nums = [1, 3, 6];
        Debug.Assert(sol.SmallestRangeII(nums, 3) == 3);

        Console.WriteLine("passed");
    }
}
