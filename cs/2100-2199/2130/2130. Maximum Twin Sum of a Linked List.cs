using System.Diagnostics;

/**
* Definition for singly-linked list.
*/
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    static public ListNode GenerateListFromVector(List<int> nodes)
    {
        ListNode prev = null, head = null;
        foreach (int node in nodes)
        {
            if (head == null)
            {
                head = new ListNode(node);
                prev = head;
            }
            else
            {
                prev.next = new ListNode(node);
                prev = prev.next;
            }
        }
        return head;
    }

    public override string ToString()
    {
        string s = "";
        for (ListNode p = this; p != null; p = p.next)
        {
            s += p.val + " -> ";
        }
        return s + "(null)";
    }
}

public class Solution {
    public int PairSum(ListNode head) {
        List<int> nodes = [];
        for (ListNode p = head; p != null; p = p.next)
        {
            nodes.Add(p.val);
        }
        int res = 0;
        for (int i = 0; i <= nodes.Count / 2 - 1; i++)
        {
            res = Math.Max(res, nodes[i] + nodes[nodes.Count - 1 - i]);
        }
        return res;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        List<int> nodes = new() { 5, 4, 2, 1 };
        ListNode head = ListNode.GenerateListFromVector(nodes);
        Debug.Assert(sol.PairSum(head) == 6);

        nodes = new() { 4, 2, 2, 3 };
        head = ListNode.GenerateListFromVector(nodes);
        Debug.Assert(sol.PairSum(head) == 7);

        nodes = new() { 1, 100000 };
        head = ListNode.GenerateListFromVector(nodes);
        Debug.Assert(sol.PairSum(head) == 100001);

        Console.WriteLine("passed");
    }
}
