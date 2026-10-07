using System.Diagnostics;

public class Solution {
    public int MinOperations(int[] nums, int x) {
        int target = nums.Sum() - x;
        if (target < 0) return -1;
        if (target == 0) return nums.Length;

        int maxLength = 0;
        for (int i = 0, j = 0, sum = 0; j < nums.Length; j++) {
            sum += nums[j];
            for (; sum > target; i++) {
                sum -= nums[i];
            }
            if (sum == target) {
                maxLength = Math.Max(maxLength, j - i + 1);
            }
        }
        return maxLength == 0 ? -1 : nums.Length - maxLength;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 1, 4, 2, 3];
        int x = 5;
        Debug.Assert(sol.MinOperations(nums, x) == 2);

        nums = [5, 6, 7, 8, 9];
        x = 4;
        Debug.Assert(sol.MinOperations(nums, x) == -1);

        nums = [3, 2, 20, 1, 1, 3];
        x = 10;
        Debug.Assert(sol.MinOperations(nums, x) == 5);

        Console.WriteLine("passed");
    }
}