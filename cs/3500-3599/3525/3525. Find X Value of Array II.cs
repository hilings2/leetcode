using System.Diagnostics;

public class Solution {
    class Node {
        public int Product;
        public int[] Counts = [];
    }

    Node Merge(Node left, Node right, int k) {
        Node merged = new() {
            Product = left.Product * right.Product % k,
            Counts = new int[k]
        };
        for (int remainder = 0; remainder < k; remainder++) {
            merged.Counts[remainder] += left.Counts[remainder];
            int combined = left.Product * remainder % k;
            merged.Counts[combined] += right.Counts[remainder];
        }
        return merged;
    }

    void Build(Node[] tree, int node, int left, int right, int[] nums, int k) {
        if (left == right) {
            int remainder = nums[left] % k;
            tree[node] = new Node {
                Product = remainder,
                Counts = new int[k]
            };
            tree[node].Counts[remainder] = 1;
            return;
        }
        int mid = left + (right - left) / 2;
        Build(tree, node * 2, left, mid, nums, k);
        Build(tree, node * 2 + 1, mid + 1, right, nums, k);
        tree[node] = Merge(tree[node * 2], tree[node * 2 + 1], k);
    }

    void Update(Node[] tree, int node, int left, int right, int index, int value, int k) {
        if (left == right) {
            int remainder = value % k;
            tree[node].Product = remainder;
            Array.Clear(tree[node].Counts);
            tree[node].Counts[remainder] = 1;
            return;
        }
        int mid = left + (right - left) / 2;
        if (index <= mid) {
            Update(tree, node * 2, left, mid, index, value, k);
        } else {
            Update(tree, node * 2 + 1, mid + 1, right, index, value, k);
        }
        tree[node] = Merge(tree[node * 2], tree[node * 2 + 1], k);
    }

    Node Query(Node[] tree, int node, int left, int right, int start, int k) {
        if (start <= left) {
            return tree[node];
        }
        int mid = left + (right - left) / 2;
        if (start > mid) {
            return Query(tree, node * 2 + 1, mid + 1, right, start, k);
        }
        Node leftResult = Query(tree, node * 2, left, mid, start, k);
        return Merge(leftResult, tree[node * 2 + 1], k);
    }

    public int[] ResultArray(int[] nums, int k, int[][] queries) {
        int n = nums.Length;
        Node[] tree = new Node[n * 4];
        Build(tree, 1, 0, n - 1, nums, k);
        int[] res = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            int index = queries[i][0];
            int value = queries[i][1];
            int start = queries[i][2];
            int x = queries[i][3];
            Update(tree, 1, 0, n - 1, index, value, k);
            Node suffix = Query(tree, 1, 0, n - 1, start, k);
            res[i] = suffix.Counts[x];
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 3, 4, 5];
        int k = 3;
        int[][] queries = [[2, 2, 0, 2], [3, 3, 3, 0], [0, 1, 0, 1]];
        int[] expected = [2, 2, 2];
        Debug.Assert(sol.ResultArray(nums, k, queries).SequenceEqual(expected));

        nums = [1, 2, 4, 8, 16, 32];
        k = 4;
        queries = [[0, 2, 0, 2], [0, 2, 0, 1]];
        expected = [1, 0];
        Debug.Assert(sol.ResultArray(nums, k, queries).SequenceEqual(expected));

        nums = [1, 1, 2, 1, 1];
        k = 2;
        queries = [[2, 1, 0, 1]];
        expected = [5];
        Debug.Assert(sol.ResultArray(nums, k, queries).SequenceEqual(expected));

        Console.WriteLine("passed");
    }
}