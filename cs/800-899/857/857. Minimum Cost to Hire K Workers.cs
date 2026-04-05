using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

public class Solution
{
    public double MincostToHireWorkers(int[] quality, int[] wage, int k)
    {
        // ratio = wage/quality
        List<(double ratio, int quality)> workers = new();
        for (int i = 0; i < quality.Length; i++)
        {
            workers.Add((wage[i] * 1.0 / quality[i], quality[i]));
        }
        // sort by ratio ascending
        workers.Sort((a, b) => a.ratio.CompareTo(b.ratio));

        double res = double.MaxValue;
        int sumQuality = 0;
        PriorityQueue<int, int> pq = new();
        // try to hire workers with smaller ratio first, then replace the worker with larger quality and recalculate the sum
        foreach (var worker in workers)
        {
            pq.Enqueue(worker.quality, -worker.quality);
            sumQuality += worker.quality;
            if (pq.Count > k)
            {
                sumQuality -= pq.Dequeue();
            }
            if (pq.Count == k)
            {
                res = Math.Min(res, sumQuality * worker.ratio);
            }
        }

        return res;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("LeetCode 857 Minimum Cost to Hire K Workers, C# ...");

        Solution sol = new();
        double epsilon = 0.00001;

        int[] quality = new int[] {10,20,5};
        int[] wage = new int[] {70,50,30};
        int k = 2;
        double expected = 105.00000;
        double actual = sol.MincostToHireWorkers(quality, wage, k);
        Debug.Assert(Math.Abs(actual - expected) < epsilon, $"Expected: {expected}, Actual: {actual}");

        quality = new int[] {3,1,10,10,1};
        wage = new int[] {4,8,2,2,7};
        k = 3;
        expected = 30.66667;
        actual = sol.MincostToHireWorkers(quality, wage, k);
        Debug.Assert(Math.Abs(actual - expected) < epsilon, $"Expected: {expected}, Actual: {actual}");
    }
}