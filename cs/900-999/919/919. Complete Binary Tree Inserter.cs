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

public class CBTInserter
{
    private List<TreeNode> nodes = [];
    public CBTInserter(TreeNode root)
    {
        nodes = [root];
        for (int i = 0; i < nodes.Count; i++)
        {
            TreeNode p = nodes[i];
            if (p.left != null)
            {
                nodes.Add(p.left);
            }
            if (p.right != null)
            {
                nodes.Add(p.right);
            }
        }
        // Console.WriteLine(string.Join(", ", nodes.Select(n => n.val)));
    }

    public int Insert(int val)
    {
        TreeNode node = new(val);
        nodes.Add(node);
        int parentIndex = (nodes.Count - 2) / 2;
        TreeNode parent = nodes[parentIndex];
        if (parent.left == null)
        {
            parent.left = node;
        }
        else
        {
            parent.right = node;
        }
        return parent.val;
    }

    public TreeNode Get_root()
    {
        return nodes[0];
    }
}

class Program
{
    // build complete binary tree from array
    public static TreeNode BuildTree(int[] values)
    {
        TreeNode root = new(values[0]);
        Queue<(TreeNode node, int index)> queue = new([(root, 0)]);
        while (queue.Count > 0)
        {
            (TreeNode p, int index) = queue.Dequeue();
            int indexLeft = (index + 1) * 2 - 1;
            if (indexLeft < values.Length)
            {
                p.left = new(values[indexLeft]);
                queue.Enqueue((p.left, indexLeft));
            }
            int indexRight = (index + 1) * 2;
            if (indexRight < values.Length)
            {
                p.right = new(values[indexRight]);
                queue.Enqueue((p.right, indexRight));
            }
        }
        return root;
    }

    // convert complete binary tree to array
    public static List<int> TreeToList(TreeNode root)
    {
        List<int> res = [];
        Queue<TreeNode> queue = new([root]);
        while (queue.Count > 0)
        {
            TreeNode p = queue.Dequeue();
            res.Add(p.val);
            if (p.left != null)
            {
                queue.Enqueue(p.left);
            }
            if (p.right != null)
            {
                queue.Enqueue(p.right);
            }
        }
        return res;
    }
    static void Main(string[] args)
    {
        TreeNode root = BuildTree([1, 2]);
        Console.WriteLine(string.Join(", ", TreeToList(root)));
        CBTInserter cBTInserter = new(root);
        Debug.Assert(cBTInserter.Insert(3) == 1);
        Debug.Assert(cBTInserter.Insert(4) == 2);
        Debug.Assert(TreeToList(cBTInserter.Get_root()).SequenceEqual([1, 2, 3, 4]));

        Console.WriteLine("passed");
    }
}
