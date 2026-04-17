using System.Diagnostics;

/**
* Definition for a binary tree node.
*/
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

public class Solution
{
    static public TreeNode Deserialize(int?[] nodes)
    {
        TreeNode[] treeNodes = new TreeNode[nodes.Length];
        for (int i = 0; i < nodes.Length; i++)
        {
            treeNodes[i] = nodes[i] != null ? new TreeNode(nodes[i].Value) : null;
        }
        for (int p = 0, q = 1; q < treeNodes.Length; p++)
        {
            if (treeNodes[p] == null)
            {
                continue;
            }

            treeNodes[p].left = treeNodes[q++];
            if (q < treeNodes.Length)
            {
                treeNodes[p].right = treeNodes[q++];
            }
        }

        return treeNodes[0];
    }

    static public int?[] Serialize(TreeNode root)
    {
        List<int?> nodes = new();
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            if (node == null)
            {
                nodes.Add(null);
                continue;
            }

            nodes.Add(node.val);
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        while (nodes.Count > 0 && nodes[nodes.Count - 1] == null)
        {
            nodes.RemoveAt(nodes.Count - 1);
        }

        Console.WriteLine(string.Join(", ", nodes.Select(p => p?.ToString() ?? "null")));
        return nodes.ToArray();
    }

    public TreeNode IncreasingBST(TreeNode root)
    {
        if (root == null || (root.left == null && root.right == null))
        {
            return root;
        }

        TreeNode left = IncreasingBST(root.left), right = IncreasingBST(root.right);
        root.left = null;
        root.right = right;
        if (left == null)
        {
            return root;
        }

        TreeNode p = left;
        while (p.right != null)
        {
            p = p.right;
        }
        p.right = root;
        return left;
    }

    public TreeNode IncreasingBST2(TreeNode root)
    {
        Stack<TreeNode> stk = new();
        List<TreeNode> inorder = new();
        TreeNode p = root;
        while (p != null || stk.Count > 0)  // in order traverse
        {
            while (p != null)
            {
                stk.Push(p);
                p = p.left;
            }

            p = stk.Pop();
            inorder.Add(p);
            p = p.right;
        }

        root = inorder[0];
        p = root;
        for (int i = 1; i < inorder.Count; i++)
        {
            p.left = null;
            p.right = inorder[i];
            p = p.right;
        }
        p.left = null;
        p.right = null;
        return root;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();
        int?[] nodes = [5, 3, 6, 2, 4, null, 8, 1, null, null, null, 7, 9];
        TreeNode root = Solution.Deserialize(nodes);
        TreeNode r = sol.IncreasingBST2(root);
        Debug.Assert(Solution.Serialize(r).SequenceEqual(new int?[] { 1, null, 2, null, 3, null, 4, null, 5, null, 6, null, 7, null, 8, null, 9 }));

        nodes = [5, 1, 7];
        root = Solution.Deserialize(nodes);
        r = sol.IncreasingBST(root);
        Debug.Assert(Solution.Serialize(r).SequenceEqual(new int?[] { 1, null, 5, null, 7 }));
    }
}
