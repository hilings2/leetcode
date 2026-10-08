using System.Diagnostics;

public class Solution {
    public int SmallestIndex(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            int sum = 0;
            for (int n = nums[i]; n > 0; n /= 10) {
                sum += n % 10;
            }
            if (sum == i) {
                return i;
            }
        }
        return -1;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 3, 2];
        Debug.Assert(sol.SmallestIndex(nums) == 2);

        nums = [1, 10, 11];
        Debug.Assert(sol.SmallestIndex(nums) == 1);

        nums = [1, 2, 3];
        Debug.Assert(sol.SmallestIndex(nums) == -1);

        Console.WriteLine("passed");
    }
}
