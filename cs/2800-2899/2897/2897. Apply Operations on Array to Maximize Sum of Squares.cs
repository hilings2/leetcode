using System.Diagnostics;

public class Solution {
    private const int BitCount = 30;
    private const int Mod = 1_000_000_007;

    public int MaxSum(IList<int> nums, int k) {
        int[] bits = new int[BitCount];
        foreach (int num in nums) {
            for (int bit = 0; bit < BitCount; bit++) {
                if ((num & (1 << bit)) != 0) {
                    bits[bit]++;
                }
            }
        }
        long result = 0;
        for (int i = 0; i < k; i++) {
            int value = 0;
            for (int bit = 0; bit < BitCount; bit++) {
                if (bits[bit] > 0) {
                    value |= 1 << bit;
                    bits[bit]--;
                }
            }
            result = (result + (long)value * value) % Mod;
        }
        return (int)result;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [2, 6, 5, 8];
        int k = 2;
        Debug.Assert(sol.MaxSum(nums, k) == 261);

        nums = [4, 5, 4, 7];
        k = 3;
        Debug.Assert(sol.MaxSum(nums, k) == 90);

        Console.WriteLine("passed");
    }
}
