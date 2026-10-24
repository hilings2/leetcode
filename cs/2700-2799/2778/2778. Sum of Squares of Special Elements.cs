using System.Diagnostics;

public class Solution {
    public int SumOfSquares(int[] nums) {
        int n = nums.Length;
        int res = 0;
        for (int i = 0; i < n; i++) {
            if (n % (i + 1) == 0) {
                res += nums[i] * nums[i];
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 3, 4];
        Debug.Assert(sol.SumOfSquares(nums) == 21);

        nums = [2, 7, 1, 19, 18, 3];
        Debug.Assert(sol.SumOfSquares(nums) == 63);

        Console.WriteLine("passed");
    }
}
