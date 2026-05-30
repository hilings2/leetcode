using System.Diagnostics;

public class Solution {
    public int MinIncrementForUnique0(int[] nums) {
        SortedDictionary<int, int> count = [];
        foreach (int num in nums) {
            count.TryAdd(num, 0);
            count[num]++;
        }
        int[] keys = [.. count.Keys];
        int next = keys.First();
        int res = 0;
        foreach (int k in keys)
        {
            if (count[k] == 1) continue;
            while (count[k] > 1)
            {
                for (next = Math.Max(k+1, next); count.ContainsKey(next); next++) ;
                res += next - k;
                count[next++] = 1;
                count[k]--;
            }
        }
        return res;
    }
    
    public int MinIncrementForUnique(int[] nums) {
        Array.Sort(nums);
        int res = 0, next = 0;
        foreach (int num in nums)
        {
            res += Math.Max(next - num, 0);
            next = Math.Max(next, num) + 1;            
        }
        return res;        
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 2];
        Debug.Assert(sol.MinIncrementForUnique(nums) == 1);

        nums = [3, 2, 1, 2, 1, 7];
        Debug.Assert(sol.MinIncrementForUnique(nums) == 6);

        Console.WriteLine("passed");
    }
}
