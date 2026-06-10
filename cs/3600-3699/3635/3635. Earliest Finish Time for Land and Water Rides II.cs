using System.Diagnostics;

public class Solution {
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration) {
        int n = landStartTime.Length, m = waterStartTime.Length;
        int res = int.MaxValue;
        int minEndTime = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            minEndTime = Math.Min(minEndTime, landStartTime[i] + landDuration[i]);
        }
        for (int j = 0; j < m; j++)
        {
            res = Math.Min(res, Math.Max(minEndTime, waterStartTime[j]) + waterDuration[j]);
        }
        
        minEndTime = int.MaxValue;
        for (int j = 0; j < m; j++)
        {
            minEndTime = Math.Min(minEndTime, waterStartTime[j] + waterDuration[j]);
        }
        for (int i = 0; i < n; i++)
        {
            res = Math.Min(res, Math.Max(minEndTime, landStartTime[i]) + landDuration[i]);
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] landStartTime = [2, 8];
        int[] landDuration = [4, 1];
        int[] waterStartTime = [6];
        int[] waterDuration = [3];
        Debug.Assert(sol.EarliestFinishTime(landStartTime, landDuration, waterStartTime, waterDuration) == 9);

        landStartTime = [5];
        landDuration = [3];
        waterStartTime = [1];
        waterDuration = [10];
        Debug.Assert(sol.EarliestFinishTime(landStartTime, landDuration, waterStartTime, waterDuration) == 14);

        Console.WriteLine("passed");
    }
}
