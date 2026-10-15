using System.Diagnostics;

public class Solution {
    public bool IsValid(string s) {
        if (s.Length % 2 != 0) return false;
        Stack<char> stack = new();
        foreach (char c in s) {
            if (c == '(' || c == '[' || c == '{') {
                stack.Push(c);
            } else {
                if (stack.Count == 0) return false;
                char top = stack.Pop();
                if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{')) return false;
            }
        }
        return stack.Count == 0;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "()";
        Debug.Assert(sol.IsValid(s) == true);

        s = "()[]{}";
        Debug.Assert(sol.IsValid(s) == true);

        s = "(]";
        Debug.Assert(sol.IsValid(s) == false);

        s = "([])";
        Debug.Assert(sol.IsValid(s) == true);

        s = "([)]";
        Debug.Assert(sol.IsValid(s) == false);

        s = "]";
        Debug.Assert(sol.IsValid(s) == false);

        Console.WriteLine("passed");
    }
}
