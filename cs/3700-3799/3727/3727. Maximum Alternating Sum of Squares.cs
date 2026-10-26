using System.Diagnostics;

public class Solution {
    public long MaxAlternatingSum(int[] nums) {
        int n = nums.Length;
        int[] abs = new int[n];
        for (int i = 0; i < n; i++) {
            abs[i] = Math.Abs(nums[i]);
        }
        Array.Sort(abs);
        long result = 0;
        for (int i = 0; i < n; i++) {
            int sign = i < n / 2 ? -1 : 1;
            result += sign * (long)abs[i] * abs[i];
        }
        return result;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 3];
        Debug.Assert(sol.MaxAlternatingSum(nums) == 12);

        nums = [1, -1, 2, -2, 3, -3];
        Debug.Assert(sol.MaxAlternatingSum(nums) == 16);

        Console.WriteLine("passed");
    }
}
