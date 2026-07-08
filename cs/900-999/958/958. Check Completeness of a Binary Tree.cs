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
    public bool IsCompleteTree(TreeNode root) {
        List<TreeNode> queue = new([root]);
        bool seenNull = false;
        for (int i = 0; i < queue.Count; i++)
        {
            TreeNode p = queue[i];
            if (p == null)
            {
                seenNull = true;
                continue;
            }
            if (seenNull) return false;
            queue.Add(p.left);
            queue.Add(p.right);
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

        TreeNode root = BuildTree([1, 2, 3, 4, 5, 6]);
        // Debug.Assert(sol.IsCompleteTree(root) == true);

        root = BuildTree([1, 2, 3, 4, 5, null, 7]);
        Debug.Assert(sol.IsCompleteTree(root) == false);

        Console.WriteLine("passed");
    }
}
