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
    public bool IsUnivalTree(TreeNode root) {
        int value = root.val;
        Queue<TreeNode> queue = new([root]);
        while (queue.Count > 0)
        {
            TreeNode p = queue.Dequeue();
            if (p.val != value) return false;
            if (p.left != null) queue.Enqueue(p.left);
            if (p.right != null) queue.Enqueue(p.right);
        }
        return true;
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

        TreeNode root = BuildTree([1, 1, 1, 1, 1, null, 1]);
        Debug.Assert(sol.IsUnivalTree(root) == true);

        root = BuildTree([2, 2, 2, 5, 2]);
        Debug.Assert(sol.IsUnivalTree(root) == false);

        Console.WriteLine("passed");
    }
}
