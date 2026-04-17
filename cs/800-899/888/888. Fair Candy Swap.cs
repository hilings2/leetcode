using System.Diagnostics;

public class Solution
{
    public int[] FairCandySwap(int[] aliceSizes, int[] bobSizes)
    {
        int sumA = 0, sumB = 0;
        HashSet<int> setA = new(), setB = new();
        foreach (int a in aliceSizes)
        {
            sumA += a;
            setA.Add(a);
        }
        foreach (int b in bobSizes)
        {
            sumB += b;
            setB.Add(b);
        }
        int diff = (sumA - sumB) / 2;
        int[] r = new int[2];
        foreach (int a in setA)
        {
            if (setB.Contains(a - diff))
            {
                r = [a, a - diff];
                break;
            }
        }
        return r;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();
        int[] aliceSizes = [1, 1];
        int[] bobSizes = [2, 2];
        Debug.Assert(sol.FairCandySwap(aliceSizes, bobSizes).SequenceEqual(new[] { 1, 2 }));

        aliceSizes = [1, 2];
        bobSizes = [2, 3];
        Debug.Assert(sol.FairCandySwap(aliceSizes, bobSizes).SequenceEqual(new[] { 1, 2 }));

        aliceSizes = [2];
        bobSizes = [1, 3];
        Debug.Assert(sol.FairCandySwap(aliceSizes, bobSizes).SequenceEqual(new[] { 2, 3 }));
    }
}
