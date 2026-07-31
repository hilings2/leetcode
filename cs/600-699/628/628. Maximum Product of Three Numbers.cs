using System.Diagnostics;

public class Solution {
    public int MaximumProduct(int[] nums) {
        int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
        int min1 = int.MaxValue, min2 = int.MaxValue;
        foreach (int num in nums) {
            if (num > max1) {
                (max3, max2, max1) = (max2, max1, num);
            } else if (num > max2) {
                (max3, max2) = (max2, num);
            } else if (num > max3) {
                max3 = num;
            }

            if (num < min1) {
                (min2, min1) = (min1, num);
            } else if (num < min2) {
                min2 = num;
            }
        }
        return Math.Max(max1 * max2 * max3, min1 * min2 * max1);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 3];
        Debug.Assert(sol.MaximumProduct(nums) == 6);

        nums = [1, 2, 3, 4];
        Debug.Assert(sol.MaximumProduct(nums) == 24);

        nums = [-1, -2, -3];
        Debug.Assert(sol.MaximumProduct(nums) == -6);

        Console.WriteLine("passed");
    }
}
