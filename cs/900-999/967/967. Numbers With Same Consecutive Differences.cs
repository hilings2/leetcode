using System.Diagnostics;

public class Solution {
    public int[] NumsSameConsecDiff(int n, int k) {
        List<int> res = [.. Enumerable.Range(1, 9)];
        for (int i = 1; i < n; i++)
        {
            List<int> next = [];
            foreach (int num in res)
            {
                int lastDigit = num % 10;
                if (k == 0)
                {
                    next.Add(num * 10 + lastDigit);
                }
                else
                {
                    if (lastDigit + k < 10)
                        next.Add(num * 10 + lastDigit + k);
                    if (lastDigit - k >= 0)
                        next.Add(num * 10 + lastDigit - k);
                }
            }
            res = next;
        }
        return [.. res];
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        Debug.Assert(sol.NumsSameConsecDiff(3, 7).OrderBy(x => x).SequenceEqual(((int[])[181, 292, 707, 818, 929]).OrderBy(x => x)));

        Debug.Assert(sol.NumsSameConsecDiff(2, 1).OrderBy(x => x).SequenceEqual(((int[])[10, 12, 21, 23, 32, 34, 43, 45, 54, 56, 65, 67, 76, 78, 87, 89, 98]).OrderBy(x => x)));

        Console.WriteLine("passed");
    }
}
