using System.Diagnostics;

public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        for (int i = 0, j = nums.Length-1; i < j; i++, j--)
        {
            for (; i < j && nums[i] % 2 == 0; i++);
            for (; i < j && nums[j] % 2 == 1; j--);
            if (i < j)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
            }
        }
        return nums;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("LeetCode 905 Sort Array By Parity, C# ...");

        Solution sol = new();

        int[] nums = new int[] {3,1,2,4};
        int[] expected = new int[] {2,4,3,1};
        int[] actual = sol.SortArrayByParity(nums);
        Debug.Assert(expected.SequenceEqual(actual), $"Expected: {string.Join(",", expected)}, Actual: {string.Join(",", actual)}");
    }
}