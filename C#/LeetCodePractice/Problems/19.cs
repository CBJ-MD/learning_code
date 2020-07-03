/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode prev = head;
        ListNode temp = head;



        for (int i = 0; i < n+1; i++)
        {
            if (temp == null)
            {
                return head.next;
            }
            temp = temp.next;
            
        }

        while (temp != null)
        {
            prev = prev.next;
            temp = temp.next;
        }

        temp = prev.next.next;
        prev.next = temp;

        return head;       
    }
}