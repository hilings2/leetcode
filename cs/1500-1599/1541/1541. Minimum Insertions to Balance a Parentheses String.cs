using System.Diagnostics;

public class Solution {
    public int MinInsertions(string s) {
        int need = 0, insert = 0;
        foreach (char c in s) {
            if (c == '(') {
                if (need % 2 == 1) {
                    insert++; // insert ) to the interrupted )
                    need--; // decrease after inserting
                }
                need += 2;
            } else {
                need--;
                if (need < 0) {
                    insert++; // insert ( to balance
                    need = 1; // after inserting (, we need one more ) to balance
                }
            }
        }
        return insert + need;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "(()))";
        Debug.Assert(sol.MinInsertions(s) == 1);

        s = "())";
        Debug.Assert(sol.MinInsertions(s) == 0);

        s = "))())(";
        Debug.Assert(sol.MinInsertions(s) == 3);

        Console.WriteLine("passed");
    }
}
