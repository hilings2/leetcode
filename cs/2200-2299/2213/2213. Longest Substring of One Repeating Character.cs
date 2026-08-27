using System.Diagnostics;


public class Solution {
    private struct Node {
        public int Length;
        public int Prefix;
        public int Suffix;
        public int Best;
        public char LeftChar;
        public char RightChar;
    }

    private char[] chars = [];
    private Node[] tree = []; // segment tree

    public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices) {
        int n = s.Length;
        chars = s.ToCharArray();
        tree = new Node[n * 4];
        Build(1, 0, n - 1);

        int[] res = new int[queryCharacters.Length];
        for (int i = 0; i < queryCharacters.Length; i++) {
            chars[queryIndices[i]] = queryCharacters[i];
            Update(1, 0, n - 1, queryIndices[i]);
            res[i] = tree[1].Best;
        }
        return res;
    }

    private static Node Leaf(char c) {
        return new Node {   // denote a substring of length 1 with character c
            Length = 1,
            Prefix = 1,
            Suffix = 1,
            Best = 1,
            LeftChar = c,
            RightChar = c
        };
    }

    private static Node Merge(in Node left, in Node right) {
        Node parent = new() { // concatenate left and right into a new substring
            Length = left.Length + right.Length,
            LeftChar = left.LeftChar,
            RightChar = right.RightChar,
            Prefix = left.Prefix,
            Suffix = right.Suffix,
            Best = Math.Max(left.Best, right.Best)
        };
        if (left.RightChar == right.LeftChar) {
            parent.Best = Math.Max(parent.Best, left.Suffix + right.Prefix);
            if (left.Prefix == left.Length) {
                parent.Prefix += right.Prefix;
            }
            if (right.Suffix == right.Length) {
                parent.Suffix += left.Suffix;
            }
        }
        return parent;
    }

    private void Build(int node, int start, int end) { // DFS to build the segment tree
        if (start == end) {
            tree[node] = Leaf(chars[start]);
        } else {
            int mid = (start + end) / 2;
            Build(node * 2, start, mid);
            Build(node * 2 + 1, mid + 1, end);
            tree[node] = Merge(tree[node * 2], tree[node * 2 + 1]);
        }
    }

    private void Update(int node, int start, int end, int index) { // update relevant branches
        if (start == end) {
            tree[node] = Leaf(chars[start]);
        } else {
            int mid = (start + end) / 2;
            if (index <= mid) {
                Update(node * 2, start, mid, index);
            } else {
                Update(node * 2 + 1, mid + 1, end, index);
            }
            tree[node] = Merge(tree[node * 2], tree[node * 2 + 1]);
        }
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "babacc";
        string queryCharacters = "bcb";
        int[] queryIndices = [1, 3, 3];
        Debug.Assert(sol.LongestRepeating(s, queryCharacters, queryIndices).SequenceEqual([3, 3, 4]));

        s = "abyzz";
        queryCharacters = "aa";
        queryIndices = [2, 1];
        Debug.Assert(sol.LongestRepeating(s, queryCharacters, queryIndices).SequenceEqual([2, 3]));

        Console.WriteLine("passed");
    }
}