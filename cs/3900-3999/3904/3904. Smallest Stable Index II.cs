using System.Diagnostics;

public class Solution {
    public int FirstStableIndex(int[] nums, int k) {
        int[] minFromRight = new int[nums.Length];
        for (int i = nums.Length - 1; i >= 0; i--) {
            minFromRight[i] = i == nums.Length - 1 ? nums[i] : Math.Min(minFromRight[i + 1], nums[i]);
        }
        int maxFromLeft = nums[0];
        for (int i = 0; i < nums.Length; i++) {
            maxFromLeft = Math.Max(maxFromLeft, nums[i]);
            if (maxFromLeft - minFromRight[i] <= k) {
                return i;
            }
        }
        return -1;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [5, 0, 1, 4];
        int k = 3;
        Debug.Assert(sol.FirstStableIndex(nums, k) == 3);

        nums = [3, 2, 1];
        k = 1;
        Debug.Assert(sol.FirstStableIndex(nums, k) == -1);

        nums = [0];
        k = 0;
        Debug.Assert(sol.FirstStableIndex(nums, k) == 0);

        Console.WriteLine("passed");
    }
}