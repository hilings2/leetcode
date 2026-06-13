using System.Diagnostics;

public class Solution {
    public int[] LeftRightDifference(int[] nums) {
        int rightSum = nums.Sum(), leftSum = 0;
        int[] result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            rightSum -= nums[i];
            result[i] = Math.Abs(leftSum - rightSum);
            leftSum += nums[i];
        }
        return result;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [10, 4, 8, 3];
        Debug.Assert(sol.LeftRightDifference(nums).SequenceEqual([15, 1, 11, 22]));

        nums = [1];
        Debug.Assert(sol.LeftRightDifference(nums).SequenceEqual([0]));

        Console.WriteLine("passed");
    }
}
