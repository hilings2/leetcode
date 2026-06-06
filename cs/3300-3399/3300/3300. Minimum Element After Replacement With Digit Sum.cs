using System.Diagnostics;

public class Solution {
    public int MinElement(int[] nums) {
        int res = int.MaxValue;
        foreach (int num in nums)
        {
            int sum = DigitSum(num);
            res = Math.Min(res, sum);
        }
        return res;
    }
    private static int DigitSum(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [10, 12, 13, 14];
        Debug.Assert(sol.MinElement(nums) == 1);

        nums = [1, 2, 3, 4];
        Debug.Assert(sol.MinElement(nums) == 1);

        nums = [999, 19, 199];
        Debug.Assert(sol.MinElement(nums) == 10);

        Console.WriteLine("passed");
    }
}
