using System.Diagnostics;

public class Solution {
    public bool IsGood(int[] nums) {
        Dictionary<int,int> count = [];
        int n = nums.Length-1;
        foreach (int a in nums)
        {
            count.TryAdd(a, 0);
            count[a]++;
            if ((a < n && count[a] > 1) || (a == n && count[a] > 2) || (a > n))
            {
                return false;
            }
        }
        return true;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [2, 1, 3];
        Debug.Assert(sol.IsGood(nums) == false);

        nums = [1, 3, 3, 2];
        Debug.Assert(sol.IsGood(nums) == true);

        nums = [1, 1];
        Debug.Assert(sol.IsGood(nums) == true);

        nums = [3, 4, 4, 1, 2, 1];
        Debug.Assert(sol.IsGood(nums) == false);

        Console.WriteLine("passed");
    }
}
