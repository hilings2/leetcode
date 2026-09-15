using System.Diagnostics;

/**
 * Definition for singly-linked list.
 */
public class ListNode {
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }

    public static ListNode GenerateList(int[] values) {
        ListNode dummy = new();
        ListNode tail = dummy;
        foreach (int value in values) {
            tail.next = new(value);
            tail = tail.next;
        }
        return dummy.next;
    }
}

public class Solution {
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        int minDistance = int.MaxValue, maxDistance = -1;
        int index = 1, firstCP = -1, prevCP = -1;
        for (ListNode prev = head, curr = head.next; curr.next != null; curr = curr.next, prev = prev.next, index++) {
            if (!((curr.val > prev.val && curr.val > curr.next.val) || (curr.val < prev.val && curr.val < curr.next.val))) {
                continue;
            }            
            if (firstCP == -1) {
                firstCP = index;
            }
            if (prevCP != -1) {
                minDistance = Math.Min(minDistance, index - prevCP);
                maxDistance = index - firstCP;
            }
            prevCP = index;
        }
        return minDistance == int.MaxValue ? [-1, -1] : [minDistance, maxDistance];
    }    
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        ListNode head = ListNode.GenerateList([3, 1]);
        Debug.Assert(sol.NodesBetweenCriticalPoints(head).SequenceEqual([-1, -1]));

        head = ListNode.GenerateList([5, 3, 1, 2, 5, 1, 2]);
        Debug.Assert(sol.NodesBetweenCriticalPoints(head).SequenceEqual([1, 3]));

        head = ListNode.GenerateList([1, 3, 2, 2, 3, 2, 2, 2, 7]);
        Debug.Assert(sol.NodesBetweenCriticalPoints(head).SequenceEqual([3, 3]));

        Console.WriteLine("passed");
    }
}
