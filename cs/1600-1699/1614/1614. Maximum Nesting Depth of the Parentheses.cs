using System.Diagnostics;

public class Solution {
    public int MaxDepth(string s) {
        int depth = 0, max = 0;
        foreach (char c in s) {
            if (c == '(') {
                depth++;
                if (depth > max) max = depth;
            } else if (c == ')') {
                depth--;
            }
        }
        return max;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "(1+(2*3)+((8)/4))+1";
        Debug.Assert(sol.MaxDepth(s) == 3);

        s = "(1)+((2))+(((3)))";
        Debug.Assert(sol.MaxDepth(s) == 3);

        s = "()(())((()()))";
        Debug.Assert(sol.MaxDepth(s) == 3);

        Console.WriteLine("passed");
    }
}
