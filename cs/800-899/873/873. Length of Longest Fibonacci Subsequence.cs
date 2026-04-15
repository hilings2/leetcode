using System.Diagnostics;

public class Solution
{
    public int LenLongestFibSubseq(int[] arr)
    {
        HashSet<int> hs = new(arr);
        int r = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                int a = arr[i], b = arr[j], l = 2;
                while (hs.Contains(a + b))
                {
                    b = a + b;
                    a = b - a;
                    l++;
                }
                if (l > 2)
                {
                    r = Math.Max(r, l);
                }
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

        int[] arr = [1, 2, 3, 4, 5, 6, 7, 8];
        Debug.Assert(sol.LenLongestFibSubseq(arr) == 5);

        arr = [1, 3, 7, 11, 12, 14, 18];
        Debug.Assert(sol.LenLongestFibSubseq(arr) == 3);
    }
}