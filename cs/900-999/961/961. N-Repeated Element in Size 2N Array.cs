using System.Diagnostics;

public class Solution {
    public int RepeatedNTimes(int[] nums) {
        Dictionary<int, int> counts = new();
        foreach (int num in nums) {
            if (counts.ContainsKey(num)) {
                return num;
            }
            counts[num] = 1;
        }
        return 0;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 3, 3];
        Debug.Assert(sol.RepeatedNTimes(nums) == 3);

        nums = [2, 1, 2, 5, 3, 2];
        Debug.Assert(sol.RepeatedNTimes(nums) == 2);

        nums = [5, 1, 5, 2, 5, 3, 5, 4];
        Debug.Assert(sol.RepeatedNTimes(nums) == 5);

        Console.WriteLine("passed");
    }
}
