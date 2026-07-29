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
    public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage) {
        List<int> res = [];
        int i = 0;

        bool Dfs(TreeNode node) {
            if (node == null) return true;
            if (node.val != voyage[i++]) return false;
            if (node.left != null && node.left.val != voyage[i]) {
                res.Add(node.val);
                return Dfs(node.right) && Dfs(node.left);
            }
            return Dfs(node.left) && Dfs(node.right);
        }

        return Dfs(root) ? res : [-1];
    }
}

class Program {
    public static TreeNode BuildTree(int?[] values)
    {
        if (values.Length == 0 || values[0] == null) return null;
        TreeNode root = new(values[0].Value);
        Queue<TreeNode> queue = new([root]);
        int i = 1;
        while (queue.Count > 0 && i < values.Length)
        {
            TreeNode p = queue.Dequeue();
            if (i < values.Length && values[i] != null)
            {
                p.left = new(values[i].Value);
                queue.Enqueue(p.left);
            }
            i++;
            if (i < values.Length && values[i] != null)
            {
                p.right = new(values[i].Value);
                queue.Enqueue(p.right);
            }
            i++;
        }
        return root;
    }

    static void Main(string[] args) {
        Solution sol = new();

        TreeNode root = BuildTree([1, 2]);
        int[] voyage = [2, 1];
        Debug.Assert(sol.FlipMatchVoyage(root, voyage).SequenceEqual([-1]));

        root = BuildTree([1, 2, 3]);
        voyage = [1, 3, 2];
        Debug.Assert(sol.FlipMatchVoyage(root, voyage).SequenceEqual([1]));

        root = BuildTree([1, 2, 3]);
        voyage = [1, 2, 3];
        Debug.Assert(sol.FlipMatchVoyage(root, voyage).SequenceEqual([]));

        Console.WriteLine("passed");
    }
}
