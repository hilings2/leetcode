using System.Diagnostics;

public class Solution {
    public int MissingInteger(int[] nums) {
        int res = 0;
        bool[] seens = new bool[51];
        bool done = false;
        for (int i = 0; i < nums.Length; i++) {
            seens[nums[i]] = true;
            if (i == 0 || (!done && nums[i] == nums[i-1] + 1)) {
                res += nums[i];
            } else {
                done = true;
            }
        }
        while (res <= 50 && seens[res]) {
            res++;
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 3, 2, 5];
        Debug.Assert(sol.MissingInteger(nums) == 6);

        nums = [3, 4, 5, 1, 12, 14, 13];
        Debug.Assert(sol.MissingInteger(nums) == 15);

        Console.WriteLine("passed");
    }
}