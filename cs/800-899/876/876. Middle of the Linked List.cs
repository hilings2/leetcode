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

public class Solution
{
    public ListNode MiddleNode(ListNode head)
    {
        ListNode slow = head;
        for (ListNode fast = head; fast != null && fast.next != null; fast = fast.next.next)
        {
            slow = slow.next;
        }
        return slow;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        List<int> nodes = new() { 1, 2, 3, 4, 5 };
        ListNode head = ListNode.GenerateListFromVector(nodes);
        ListNode middle = sol.MiddleNode(head);
        Debug.Assert(middle.val == 3);

        nodes = new() { 1, 2, 3, 4, 5, 6 };
        head = ListNode.GenerateListFromVector(nodes);
        middle = sol.MiddleNode(head);
        Debug.Assert(middle.val == 4);
    }
}
