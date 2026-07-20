using System.Diagnostics;

public class Solution {
    public long GcdSum(int[] nums) {
        int n = nums.Length;
        int maxNum = 0;
        int[] prefixGcd = new int[n];
        for (int i = 0; i < n; i++) {
            maxNum = Math.Max(maxNum, nums[i]);
            prefixGcd[i] = Gcd(nums[i], maxNum);
        }
        Array.Sort(prefixGcd);
        long res = 0;
        for (int i = 0, j = n - 1; i < j; i++, j--) {
            res += Gcd(prefixGcd[i], prefixGcd[j]);
        }
        return res;
    }

    private static int Gcd(int a, int b) {
        while (b != 0) {
            (a, b) = (b, a % b);
        }
        return a;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [2, 6, 4];
        Debug.Assert(sol.GcdSum(nums) == 2);

        nums = [3, 6, 2, 8];
        Debug.Assert(sol.GcdSum(nums) == 5);

        Console.WriteLine("passed");
    }
}
