using System.Diagnostics;

public class Solution {
    public int FindGCD(int[] nums) {
        int min = nums[0], max = nums[0];
        foreach (int num in nums) {
            if (num < min) min = num;
            if (num > max) max = num;
        }
        return Gcd(min, max);
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }
        return a;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [2, 5, 6, 9, 10];
        Debug.Assert(sol.FindGCD(nums) == 2);

        nums = [7, 5, 6, 8, 3];
        Debug.Assert(sol.FindGCD(nums) == 1);

        nums = [3, 3];
        Debug.Assert(sol.FindGCD(nums) == 3);

        Console.WriteLine("passed");
    }
}
