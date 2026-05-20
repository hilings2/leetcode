using System.Diagnostics;

public class Solution
{
    public int FindMin(int[] nums)
    {
        int i = 0, j = nums.Length - 1;
        while (i < j)
        {
            if (nums[i] <= nums[j])
            {
                return nums[i];
            }
            int m = i + (j - i) / 2;
            (i, j) = nums[i] <= nums[m] ? (m + 1, j) : (i, m);
        }
        return nums[i];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] nums = [3, 4, 5, 1, 2];
        Debug.Assert(sol.FindMin(nums) == 1);

        nums = [4, 5, 6, 7, 0, 1, 2];
        Debug.Assert(sol.FindMin(nums) == 0);

        nums = [11, 13, 15, 17];
        Debug.Assert(sol.FindMin(nums) == 11);

        Console.WriteLine("passed");
    }
}