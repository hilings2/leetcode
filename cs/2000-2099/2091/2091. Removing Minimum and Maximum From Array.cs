using System.Diagnostics;

public class Solution {
    public int MinimumDeletions(int[] nums) {
        int minIndex = 0, maxIndex = 0;
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] < nums[minIndex]) {
                minIndex = i;
            }
            if (nums[i] > nums[maxIndex]) {
                maxIndex = i;
            }
        }
        if (minIndex > maxIndex) {
            (minIndex, maxIndex) = (maxIndex, minIndex);
        }
        int res = Math.Min(maxIndex + 1, nums.Length - minIndex);
        return Math.Min(res, minIndex + 1 + nums.Length - maxIndex);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [2, 10, 7, 5, 4, 1, 8, 6];
        Debug.Assert(sol.MinimumDeletions(nums) == 5);

        nums = [0, -4, 19, 1, 8, -2, -3, 5];
        Debug.Assert(sol.MinimumDeletions(nums) == 3);

        nums = [101];
        Debug.Assert(sol.MinimumDeletions(nums) == 1);

        Console.WriteLine("passed");
    }
}
