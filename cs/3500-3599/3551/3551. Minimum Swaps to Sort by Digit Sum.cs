using System.Diagnostics;

public class Solution {
    public int MinSwaps(int[] nums) {
        int n = nums.Length;
        long[] keys = new long[n];
        int[] idx = new int[n];
        for (int i = 0; i < n; i++) {
            keys[i] = ((long)DigitSum(nums[i]) << 32) | (uint)nums[i]; // first digit sum, then value
            idx[i] = i;
        }
        Array.Sort(keys, idx); // sort nums and their original indices
        
        int cycles = 0;
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++) { // find number of cycles
            if (visited[i]) continue;
            cycles++;
            for (int j = i; !visited[j]; j = idx[j]) {
                visited[j] = true;
            }
        }
        return n - cycles;
    }

    public int MinSwaps0(int[] nums) {
        int[] sorted = (int[])nums.Clone();
        Array.Sort(sorted, (a, b) => { // sort by digit sum, then by value
            int cmp = DigitSum(a).CompareTo(DigitSum(b));
            return cmp != 0 ? cmp : a.CompareTo(b);
        });
        Dictionary<int, int> targetIndex = []; // lookup from num to its destiny
        for (int i = 0; i < sorted.Length; i++) {
            targetIndex[sorted[i]] = i;
        }
        int n = nums.Length, cycles = 0;
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++) { // find number of cycles
            if (visited[i]) continue;
            cycles++;
            for (int j = i; !visited[j]; j = targetIndex[nums[j]]) {
                visited[j] = true;
            }
        }
        return n - cycles;
    }

    private static int DigitSum(int num) {
        int sum = 0;
        for (int tmp = num; tmp > 0; tmp /= 10) {
            sum += tmp % 10;
        }
        return sum;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [37, 100];
        Debug.Assert(sol.MinSwaps(nums) == 1);

        nums = [22, 14, 33, 7];
        Debug.Assert(sol.MinSwaps(nums) == 0);

        nums = [18, 43, 34, 16];
        Debug.Assert(sol.MinSwaps(nums) == 2);

        Console.WriteLine("passed");
    }
}
