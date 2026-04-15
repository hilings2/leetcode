using System.Diagnostics;

public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int highest = 0;
        foreach (int pile in piles)
        {
            highest = Math.Max(highest, pile);
        }

        int left = 1, right = highest;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (RequiredHours(piles, mid) <= h)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        return left;
    }

    public int RequiredHours(int[] piles, int k)
    {
        int h = 0;
        for (int i = 0; i < piles.Length; i++)
        {
            h += (piles[i] + k - 1) / k;
        }
        return h;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] piles = [3, 6, 7, 11];
        int h = 8;
        Debug.Assert(sol.MinEatingSpeed(piles, h) == 4);

        piles = [30, 11, 23, 4, 20];
        h = 5;
        Debug.Assert(sol.MinEatingSpeed(piles, h) == 30);

        piles = [30, 11, 23, 4, 20];
        h = 6;
        Debug.Assert(sol.MinEatingSpeed(piles, h) == 23);
    }
}
