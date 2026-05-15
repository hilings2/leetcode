using System.Diagnostics;

public class Solution
{
    public int[] MaxValue(int[] nums)
    {
        int max = 0;
        int[] res = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            max = Math.Max(max, nums[i]);
            res[i] = max;
        }
        int min = int.MaxValue;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (res[i] > min)
            {
                res[i] = res[i+1];
            }
            min = Math.Min(min, nums[i]);
        }
        return res;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] nums = [2, 1, 3];
        Debug.Assert(sol.MaxValue(nums).SequenceEqual([2, 2, 3]));

        nums = [2, 3, 1];
        Debug.Assert(sol.MaxValue(nums).SequenceEqual([3, 3, 3]));
        
        nums = [3, 1, 4, 2];
        Debug.Assert(sol.MaxValue(nums).SequenceEqual([4, 4, 4, 4]));

        nums = [3, 4, 1, 5, 2, 6];
        Debug.Assert(sol.MaxValue(nums).SequenceEqual([5, 5, 5, 5, 5, 6]));
        
        Console.WriteLine("passed");
    }
}
