using System.Diagnostics;

public class Solution {
    public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
        return rec1[0] < rec2[2] && rec1[2] > rec2[0] && rec1[1] < rec2[3] && rec1[3] > rec2[1];
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] rec1 = [0, 0, 2, 2];
        int[] rec2 = [1, 1, 3, 3];
        Debug.Assert(sol.IsRectangleOverlap(rec1, rec2) == true);

        rec1 = [0, 0, 1, 1];
        rec2 = [1, 0, 2, 1];
        Debug.Assert(sol.IsRectangleOverlap(rec1, rec2) == false);

        rec1 = [0, 0, 1, 1];
        rec2 = [2, 2, 3, 3];
        Debug.Assert(sol.IsRectangleOverlap(rec1, rec2) == false);

        Console.WriteLine("passed");
    }
}