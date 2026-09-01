using System.Diagnostics;

public class Solution {
    public int LargestInteger(int[] nums, int k) {
        if (k == nums.Length) {
            return nums.Max();
        }
        int[] counts = new int[51];
        foreach (int num in nums) {
            counts[num]++;
        }
        if (k == 1) {
            for (int i = 50; i >= 0; i--) {
                if (counts[i] == 1) {
                    return i;
                }
            }
            return -1;
        }
        int largest = -1;
        if (counts[nums[^1]] == 1) {
            largest = nums[^1];
        }
        if (counts[nums[0]] == 1) {
            largest = Math.Max(largest, nums[0]);
        }
        return largest;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [3, 9, 2, 1, 7];
        int k = 3;
        Debug.Assert(sol.LargestInteger(nums, k) == 7);

        nums = [3, 9, 7, 2, 1, 7];
        k = 4;
        Debug.Assert(sol.LargestInteger(nums, k) == 3);

        nums = [0, 0];
        k = 1;
        Debug.Assert(sol.LargestInteger(nums, k) == -1);

        Console.WriteLine("passed");
    }
}
