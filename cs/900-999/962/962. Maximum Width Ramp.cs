using System.Diagnostics;

public class Solution {
    public int MaxWidthRamp(int[] nums) {
        Stack<int> stack = [];
        for (int i = 0; i < nums.Length; i++)
        {
            if (stack.Count == 0 || nums[i] < nums[stack.Peek()])
            {
                stack.Push(i);
            }
        }
        int res = 0;
        for (int j = nums.Length - 1; j >= 0; j--)
        {
            while (stack.Count > 0 && nums[j] >= nums[stack.Peek()])
            {
                res = Math.Max(res, j - stack.Pop());
            }
        }
        return res;
    }
    
    public int MaxWidthRamp0(int[] nums) {
        int res = 0;
        for (int i = 0; i < nums.Length; i++) {
            for (int j = nums.Length - 1; j > i; j--) {
                if (nums[i] <= nums[j]) {
                    res = Math.Max(res, j - i);
                    break;
                }
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [6, 0, 8, 2, 1, 5];
        Debug.Assert(sol.MaxWidthRamp(nums) == 4);

        nums = [9, 8, 1, 0, 1, 9, 4, 0, 4, 1];
        Debug.Assert(sol.MaxWidthRamp(nums) == 7);

        Console.WriteLine("passed");
    }
}
