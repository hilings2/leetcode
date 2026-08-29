using System.Diagnostics;

public class Solution {
    public int LongestSubsequence(int[] nums) {
        int totalXor = 0;
        bool anyNonZero = false;
        foreach (int num in nums) {
            totalXor ^= num;
            if (num != 0) anyNonZero = true;
        }
        if (totalXor != 0) return nums.Length;
        if (anyNonZero) return nums.Length - 1;
        return 0;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 3];
        Debug.Assert(sol.LongestSubsequence(nums) == 2);

        nums = [2, 3, 4];
        Debug.Assert(sol.LongestSubsequence(nums) == 3);

        Console.WriteLine("passed");
    }
}