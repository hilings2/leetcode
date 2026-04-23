using System.Diagnostics;

public class Solution {
    public int PartitionDisjoint(int[] nums) {
        int maxLeft = nums[0];
        int maxSoFar = nums[0];
        int index = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < maxLeft)
            {
                index = i;
                maxLeft = maxSoFar;
            }
            else
            {
                maxSoFar = Math.Max(maxSoFar, nums[i]);
            }            
        }
        return index + 1;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [5, 0, 3, 8, 6];
        Debug.Assert(sol.PartitionDisjoint(nums) == 3);

        nums = [1, 1, 1, 0, 6, 12];
        Debug.Assert(sol.PartitionDisjoint(nums) == 4);

        Console.WriteLine("passed");
    }
}