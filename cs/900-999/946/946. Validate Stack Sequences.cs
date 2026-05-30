using System.Diagnostics;

public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        Stack<int> stk = [];
        for (int i = 0, j = 0; j < popped.Length;) {
            if (stk.Count == 0 || stk.Peek() != popped[j]) {
                if (i == pushed.Length) return false;
                stk.Push(pushed[i++]);
                continue;
            }
            stk.Pop();
            j++;
        }
        return stk.Count == 0;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] pushed = [1, 2, 3, 4, 5];
        int[] popped = [4, 5, 3, 2, 1];
        Debug.Assert(sol.ValidateStackSequences(pushed, popped) == true);

        pushed = [1, 2, 3, 4, 5];
        popped = [4, 3, 5, 1, 2];
        Debug.Assert(sol.ValidateStackSequences(pushed, popped) == false);

        Console.WriteLine("passed");
    }
}
