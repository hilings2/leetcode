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
    public bool FlipEquiv(TreeNode root1, TreeNode root2) {
        if (root1 == null && root2 == null) return true;
        if (root1 == null || root2 == null) return false;
        if (root1.val != root2.val) return false;
        if (FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right)) return true;
        if (FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left)) return true;
        return false;
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

        TreeNode root1 = BuildTree([1, 2, 3, 4, 5, 6, null, null, null, 7, 8]);
        TreeNode root2 = BuildTree([1, 3, 2, null, 6, 4, 5, null, null, null, null, 8, 7]);
        Debug.Assert(sol.FlipEquiv(root1, root2) == true);

        root1 = BuildTree([]);
        root2 = BuildTree([]);
        Debug.Assert(sol.FlipEquiv(root1, root2) == true);

        root1 = BuildTree([]);
        root2 = BuildTree([1]);
        Debug.Assert(sol.FlipEquiv(root1, root2) == false);

        Console.WriteLine("passed");
    }
}
