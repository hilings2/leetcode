using System.Diagnostics;

public class Solution
{
    public int MinFlipsMonoIncr(string s)
    {
        int count_flip = 0;
        int count1 = 0;     // number of 1 so far, also meaning flips needed if flipping all 1 into 0
        foreach (char c in s)
        {
            if (c == '1')
            {
                count1++;
            }
            else
            {
                count_flip++;
            }
            count_flip = Math.Min(count_flip, count1);  // either flip all 1s so far into 0, or flip the last 0 into 1
        }
        return count_flip;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        string s = "00110";
        Debug.Assert(sol.MinFlipsMonoIncr(s) == 1);

        s = "010110";
        Debug.Assert(sol.MinFlipsMonoIncr(s) == 2);

        s = "00011000";
        Debug.Assert(sol.MinFlipsMonoIncr(s) == 2);

        s = "10011111110010111011";
        Debug.Assert(sol.MinFlipsMonoIncr(s) == 5);

        Console.WriteLine("passed");
    }
}
