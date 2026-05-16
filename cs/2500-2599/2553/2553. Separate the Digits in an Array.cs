using System.Diagnostics;

public class Solution {
    public int[] SeparateDigits(int[] nums) {
        List<int> res = [];
        foreach (int n in nums)
        {
            res.AddRange(digits(n));
        }
        return res.ToArray();
    }

    private static List<int> digits(int n)
    {
        List<int> res = [];
        while (n > 0)
        {
            res.Add(n % 10);
            n /= 10;
        }
        res.Reverse();
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [13, 25, 83, 77];
        Debug.Assert(sol.SeparateDigits(nums).SequenceEqual([1, 3, 2, 5, 8, 3, 7, 7]));

        nums = [7, 1, 3, 9];
        Debug.Assert(sol.SeparateDigits(nums).SequenceEqual([7, 1, 3, 9]));

        Console.WriteLine("passed");
    }
}
