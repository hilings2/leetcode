using System.Diagnostics;

public class Solution {
    public int[] SortArrayByParityII(int[] nums) {
        for (int even = 0, odd = 1; even < nums.Length && odd < nums.Length; even += 2, odd += 2)
        {
            for (; even < nums.Length && nums[even] % 2 == 0; even+=2);
            for (; odd < nums.Length && nums[odd] % 2 == 1; odd+=2);
            if (even < nums.Length && odd < nums.Length)
            {
                (nums[even], nums[odd]) = (nums[odd], nums[even]);
            }
        }
        return nums;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [4, 2, 5, 7];
        Debug.Assert(sol.SortArrayByParityII(nums).SequenceEqual([4, 5, 2, 7]));

        nums = [2, 3];
        Debug.Assert(sol.SortArrayByParityII(nums).SequenceEqual([2, 3]));

        Console.WriteLine("passed");
    }
}