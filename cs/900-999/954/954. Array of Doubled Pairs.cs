using System.Diagnostics;

public class Solution {
    public bool CanReorderDoubled(int[] arr) {
        SortedDictionary<int, int> dict = [];
        foreach (int num in arr) {
            dict.TryAdd(num, 0);
            dict[num]++;
        }
        int[] keys = [.. dict.Keys];
        foreach (int k in keys)
        {
            int v = dict[k];
            if (v == 0) continue;
            if (k < 0)
            {
                if (k % 2 != 0 || !dict.ContainsKey(k / 2) || dict[k / 2] < v) return false;
                dict[k/2] -= v;
            }
            else if (k > 0)
            {
                if (!dict.ContainsKey(k * 2) || dict[k * 2] < v) return false;
                dict[k * 2] -= v;
            }
            else
            {
                if (v % 2 != 0) return false;
            }
        }
        return true;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] arr = [3, 1, 3, 6];
        Debug.Assert(sol.CanReorderDoubled(arr) == false);

        arr = [2, 1, 2, 6];
        Debug.Assert(sol.CanReorderDoubled(arr) == false);

        arr = [4, -2, 2, -4];
        Debug.Assert(sol.CanReorderDoubled(arr) == true);

        Console.WriteLine("passed");
    }
}
