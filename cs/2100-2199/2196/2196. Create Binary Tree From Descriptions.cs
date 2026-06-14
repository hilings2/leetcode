using System.Diagnostics;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        Dictionary<int, TreeNode> nodes = [];
        Dictionary<int, bool> isRoot = [];
        foreach (int[] d in descriptions)
        {
            (int parent, int child, int isLeft) = (d[0], d[1], d[2]);
            if (!nodes.ContainsKey(parent))
            {
                nodes[parent] = new TreeNode(parent);
                isRoot[parent] = true;
            }
            if (!nodes.ContainsKey(child))
            {
                nodes[child] = new TreeNode(child);
            }
            isRoot[child] = false;
            if (isLeft == 1) {
                nodes[parent].left = nodes[child];
            } else {
                nodes[parent].right = nodes[child];
            }
        }
        int root = isRoot.Where(kv => kv.Value).Select(kv => kv.Key).First();
        return nodes[root];
    }
}

class Program {
    // convert binary tree to LeetCode level-order serialization with trailing nulls trimmed
    public static List<int?> TreeToList(TreeNode root)
    {
        List<int?> res = [];
        Queue<TreeNode> queue = new([root]);
        while (queue.Count > 0)
        {
            TreeNode p = queue.Dequeue();
            if (p == null)
            {
                res.Add(null);
                continue;
            }
            res.Add(p.val);
            queue.Enqueue(p.left);
            queue.Enqueue(p.right);
        }
        while (res.Count > 0 && res[^1] == null)
        {
            res.RemoveAt(res.Count - 1);
        }
        return res;
    }

    static void Main(string[] args) {
        Solution sol = new();

        int[][] descriptions = [[20, 15, 1], [20, 17, 0], [50, 20, 1], [50, 80, 0], [80, 19, 1]];
        Debug.Assert(TreeToList(sol.CreateBinaryTree(descriptions)).SequenceEqual([50, 20, 80, 15, 17, 19]));

        descriptions = [[1, 2, 1], [2, 3, 0], [3, 4, 1]];
        Debug.Assert(TreeToList(sol.CreateBinaryTree(descriptions)).SequenceEqual([1, 2, null, null, 3, 4]));

        Console.WriteLine("passed");
    }
}
