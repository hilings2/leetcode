using System.Diagnostics;

public class Solution {
    public int MinAddToMakeValid(string s) {
        Stack<char> stack = new();
        int count = 0;
        foreach (char c in s)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (stack.Count > 0 && stack.Peek() == '(')
            {
                stack.Pop();
            }
            else
            {
                count++;
            }
        }
        return stack.Count + count;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "())";
        Debug.Assert(sol.MinAddToMakeValid(s) == 1);

        s = "(((";
        Debug.Assert(sol.MinAddToMakeValid(s) == 3);

        Console.WriteLine("passed");
    }
}
