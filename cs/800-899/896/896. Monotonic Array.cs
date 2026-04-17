using System.Diagnostics;

public class Solution
{
    public bool IsMonotonic(int[] nums)
    {
        int trend = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                continue;
            }

            if (trend == 0)
            {
                trend = nums[i] > nums[i - 1] ? 1 : -1;
                continue;
            }

            if ((nums[i] > nums[i - 1] && trend == -1) || (nums[i] < nums[i - 1] && trend == 1))
            {
                return false;
            }
        }

        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();
        int[] nums = [1, 2, 2, 3];
        Debug.Assert(sol.IsMonotonic(nums) == true);

        nums = [6, 5, 4, 4];
        Debug.Assert(sol.IsMonotonic(nums) == true);

        nums = [1, 3, 2];
        Debug.Assert(sol.IsMonotonic(nums) == false);
    }
}
