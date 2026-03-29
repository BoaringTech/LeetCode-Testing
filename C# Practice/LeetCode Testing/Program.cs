// See https://aka.ms/new-console-template for more information

ListNode head = new ListNode(1);
ListNode prev = head;
for(int i = 2; i < 6; i++)
{
    prev.next = new ListNode(i);
    prev = prev.next;
}

new Solution().ReverseBetween(head, 2, 4);

public class Solution
{
    public int StrStr(string haystack, string needle)
    {

        // Needle cannot be bigger than haystack
        if (needle.Length > haystack.Length)
            return -1;

        int pnl = 0; //potentialNeedleLength

        for (int i = 0; i < haystack.Length; i++)
        {
            // Letter mismatched, reset pnl
            if (haystack[i] != needle[pnl])
            {
                pnl = 0;
                continue;
            }

            ++pnl;
            // pnl matches needle length, we found the needle, 
            // return starting index of needle
            if ( pnl == needle.Length)
            {
                return i - pnl + 1;
            }

            //pnl was incremented to compare the successive needle letter
        }

        return -1;
    }

    public ListNode ReverseBetween(ListNode head, int left, int right)
    {

        if (head.val > left)
        {
            return head;
        }

        ListNode tp = head;
        ListNode prev = null;

        while (tp.val < left)
        {
            prev = tp;
            tp = tp.next;
        }

        if (tp.val != left)
        {
            return head;
        }

        if(prev != null)
        {
            prev.next = Reverse(tp, right);
            return head;
        }

        return Reverse(tp, right);
    }

    private ListNode Reverse(ListNode head, int right)
    {
        ListNode prev = null;
        ListNode current = head;
        ListNode next = null;
        ListNode last = head;

        while (current.val <= right)
        {
            next = current.next;
            current.next = prev;

            if (next == null)
            {
                break;
            }

            prev = current;
            current = next;
        }

        last.next = current;

        return prev;
    }
}



public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
