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
    public int RangeSumBST(TreeNode root, int low, int high) {
        Queue<TreeNode> q = new([root]);
        int sum = 0;
        while (q.Count > 0)
        {
            TreeNode p = q.Dequeue();
            if (p.val >= low && p.val <= high)
            {
                sum += p.val;
            }
            if (p.left != null && p.val > low)
            {
                q.Enqueue(p.left);
            }
            if (p.right != null && p.val < high)
            {
                q.Enqueue(p.right);
            }
        }
        return sum;
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

        TreeNode root = BuildTree([10, 5, 15, 3, 7, null, 18]);
        Debug.Assert(sol.RangeSumBST(root, 7, 15) == 32);

        root = BuildTree([10, 5, 15, 3, 7, 13, 18, 1, null, 6]);
        Debug.Assert(sol.RangeSumBST(root, 6, 10) == 23);

        Console.WriteLine("passed");
    }
}
