using System.Diagnostics;

public class Solution {
    public int[] MaxDepthAfterSplit(string seq) {
        int[] res = new int[seq.Length];
        int depth = 0;
        for (int i = 0; i < seq.Length; i++) {
            if (seq[i] == '(') {
                depth++;
                res[i] = (depth - 1) % 2;
            } else {
                res[i] = (depth - 1) % 2;
                depth--;
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string seq = "(()())";
        Debug.Assert(IsValidSplit(seq, sol.MaxDepthAfterSplit(seq))); // [0, 1, 1, 1, 1, 0]

        seq = "()(())()";
        Debug.Assert(IsValidSplit(seq, sol.MaxDepthAfterSplit(seq))); // [0, 0, 0, 1, 1, 0, 0, 0]

        seq = "((()))";
        Debug.Assert(IsValidSplit(seq, sol.MaxDepthAfterSplit(seq))); // [0, 1, 0, 0, 1, 0]

        seq = "()";
        Debug.Assert(IsValidSplit(seq, sol.MaxDepthAfterSplit(seq))); // [0, 0]

        Debug.Assert(IsValidSplit("()(())()", [0, 0, 0, 1, 1, 0, 1, 1]));
        Debug.Assert(IsValidSplit("()(())()", [0, 0, 0, 1, 1, 0, 0, 0]));
        Debug.Assert(IsValidSplit("()", [1, 1]));

        Console.WriteLine("passed");
    }

    static bool IsValidSplit(string seq, int[] answer) {
        if (answer.Length != seq.Length) return false;

        int[] depths = new int[2];
        int maxOriginalDepth = 0;
        int maxSplitDepth = 0;

        for (int i = 0; i < seq.Length; i++) {
            int group = answer[i];
            if (group != 0 && group != 1) return false;
            if (seq[i] != '(' && seq[i] != ')') return false;

            depths[group] += seq[i] == '(' ? 1 : -1;
            if (depths[group] < 0) return false;

            maxOriginalDepth = Math.Max(maxOriginalDepth, depths[0] + depths[1]);
            maxSplitDepth = Math.Max(maxSplitDepth, depths[group]);
        }

        // At the deepest point, at least one group must contain half the open parentheses.
        int optimalDepth = (maxOriginalDepth + 1) / 2;
        return depths[0] == 0 && depths[1] == 0 && maxSplitDepth == optimalDepth;
    }
}
