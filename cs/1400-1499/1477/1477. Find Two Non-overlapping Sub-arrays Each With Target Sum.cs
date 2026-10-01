using System.Diagnostics;

public class Solution {
    public int MinSumOfLengths(int[] arr, int target) {
        int sum = 0;
        int res = int.MaxValue;
        int[] best = new int[arr.Length];
        Array.Fill(best, int.MaxValue);

        for (int left = 0, right = 0; right < arr.Length; right++) {
            sum += arr[right];
            for (; sum > target; left++) {
                sum -= arr[left];
            }
            int shortest = right > 0 ? best[right - 1] : int.MaxValue;
            if (sum == target) { // found a valid subarray
                int length = right - left + 1;
                if (left > 0 && best[left - 1] != int.MaxValue) { // there is a previous non-overlapping subarray
                    res = Math.Min(res, best[left - 1] + length);
                }
                shortest = Math.Min(shortest, length); // refresh shortest valid subarray
            }
            best[right] = shortest;
        }
        return res == int.MaxValue ? -1 : res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] arr = [3, 2, 2, 4, 3];
        int target = 3;
        Debug.Assert(sol.MinSumOfLengths(arr, target) == 2);

        arr = [7, 3, 4, 7];
        target = 7;
        Debug.Assert(sol.MinSumOfLengths(arr, target) == 2);

        arr = [4, 3, 2, 6, 2, 3, 4];
        target = 6;
        Debug.Assert(sol.MinSumOfLengths(arr, target) == -1);

        Console.WriteLine("passed");
    }
}