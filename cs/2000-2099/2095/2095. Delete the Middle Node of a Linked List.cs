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
    public ListNode DeleteMiddle(ListNode head) {
        ListNode head0 = new ListNode(0, head);
        ListNode slow = head0, fast = head0;
        while (fast.next != null && fast.next.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }
        slow.next = slow.next.next;
        return head0.next;
    }

}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        ListNode head = ListNode.GenerateListFromVector(new() { 1, 3, 4, 7, 1, 2, 6 });
        Debug.Assert(sol.DeleteMiddle(head).ToString() == "1 -> 3 -> 4 -> 1 -> 2 -> 6 -> (null)");

        head = ListNode.GenerateListFromVector(new() { 1, 2, 3, 4 });
        Debug.Assert(sol.DeleteMiddle(head).ToString() == "1 -> 2 -> 4 -> (null)");

        head = ListNode.GenerateListFromVector(new() { 2, 1 });
        Debug.Assert(sol.DeleteMiddle(head).ToString() == "2 -> (null)");

        Console.WriteLine("passed");
    }
}
