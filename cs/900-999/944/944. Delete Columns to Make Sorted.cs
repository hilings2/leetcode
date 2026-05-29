using System.Diagnostics;

public class Solution {
    public int MinDeletionSize(string[] strs) {
        int rows = strs.Length, cols = strs[0].Length;
        int res = 0;
        for (int j = 0; j < cols; j++)
        {
            for (int i = 1; i < rows; i++)
            {
                if (strs[i][j] >= strs[i-1][j]) continue;
                res++;
                break;
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] strs = ["cba", "daf", "ghi"];
        Debug.Assert(sol.MinDeletionSize(strs) == 1);

        strs = ["a", "b"];
        Debug.Assert(sol.MinDeletionSize(strs) == 0);

        strs = ["zyx", "wvu", "tsr"];
        Debug.Assert(sol.MinDeletionSize(strs) == 3);

        Console.WriteLine("passed");
    }
}
