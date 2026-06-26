using System.Diagnostics;

public class Solution {
    public int MinDeletionSize(string[] strs) {
        int rows = strs.Length, cols = strs[0].Length, res = 0;
        bool[] sorted = new bool[rows - 1];
        for (int j = 0, i; j < cols; j++)
        {
            for (i = 0; i < rows - 1; i++)
            {
                if (!sorted[i] && strs[i][j] > strs[i+1][j])
                {
                    res++;
                    break;
                }
            }
            if (i < rows - 1) continue;
            // deleted column will not reach here
            for (i = 0; i < rows - 1; i++)
            {
                // true if already sorted, or strictly increasing
                // if equal, will evaluate by next column
                sorted[i] = sorted[i] || strs[i][j] < strs[i+1][j];                
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] strs = ["ca", "bb", "ac"];
        Debug.Assert(sol.MinDeletionSize(strs) == 1);

        strs = ["xc", "yb", "za"];
        Debug.Assert(sol.MinDeletionSize(strs) == 0);

        strs = ["zyx", "wvu", "tsr"];
        Debug.Assert(sol.MinDeletionSize(strs) == 3);

        Console.WriteLine("passed");
    }
}
