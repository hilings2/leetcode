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
    public int AverageOfSubtree(TreeNode root) {
        return Eval(root).match;
    }

    private static (int sum, int count, int match) Eval(TreeNode root) {
        if (root == null) return (0, 0, 0);
        (int sum, int count, int match) evalLeft = Eval(root.left), evalRight = Eval(root.right);
        int sum = root.val + evalLeft.sum + evalRight.sum;
        int count = 1 + evalLeft.count + evalRight.count;
        int match = (sum / count == root.val ? 1 : 0) + evalLeft.match + evalRight.match;
        return (sum, count, match);
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
            TreeNode node = queue.Dequeue();
            if (i < values.Length && values[i] != null)
            {
                node.left = new(values[i].Value);
                queue.Enqueue(node.left);
            }
            i++;
            if (i < values.Length && values[i] != null)
            {
                node.right = new(values[i].Value);
                queue.Enqueue(node.right);
            }
            i++;
        }
        return root;
    }

    static void Main(string[] args) {
        Solution sol = new();

        TreeNode root = BuildTree([4, 8, 5, 0, 1, null, 6]);
        Debug.Assert(sol.AverageOfSubtree(root) == 5);

        root = BuildTree([1]);
        Debug.Assert(sol.AverageOfSubtree(root) == 1);

        Console.WriteLine("passed");
    }
}