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

    public int[] ToArray()
    {
        List<int> nodes = [];
        for (ListNode p = this; p != null; p = p.next)
        {
            nodes.Add(p.val);
        }
        return nodes.ToArray();
    }
}

public class Solution
{
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || head.next == null || k == 0)
        {
            return head;
        }
        int len = 1;
        ListNode tail = head;
        while (tail.next != null)
        {
            tail = tail.next;
            len++;
        }
        tail.next = head;
        k %= len;
        for (int i = 0; i < len - k; i++)
        {
            tail = tail.next;
        }
        head = tail.next;
        tail.next = null;
        return head;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        List<int> nodes = [1, 2, 3, 4, 5];
        ListNode head = ListNode.GenerateListFromVector(nodes);
        Debug.Assert(sol.RotateRight(head, 2).ToArray().SequenceEqual([4, 5, 1, 2, 3]));

        nodes = [0, 1, 2];
        head = ListNode.GenerateListFromVector(nodes);
        Debug.Assert(sol.RotateRight(head, 4).ToArray().SequenceEqual([2, 0, 1]));

        Console.WriteLine("passed");
    }
}
