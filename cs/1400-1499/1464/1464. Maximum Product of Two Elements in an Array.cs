using System.Diagnostics;

public class Solution {
    public int MaxProduct(int[] nums) {
        int max1 = 0, max2 = 0;
        foreach (int num in nums) {
            if (num > max1) {
                (max2, max1) = (max1, num);
            } else if (num > max2) {
                max2 = num;
            }
        }
        return (max1 - 1) * (max2 - 1);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [3, 4, 5, 2];
        Debug.Assert(sol.MaxProduct(nums) == 12);

        nums = [1, 5, 4, 5];
        Debug.Assert(sol.MaxProduct(nums) == 16);

        nums = [3, 7];
        Debug.Assert(sol.MaxProduct(nums) == 12);

        Console.WriteLine("passed");
    }
}
