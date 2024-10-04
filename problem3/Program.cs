using System;

public class LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int value = 0)
        {
            val = value;
            next = null;
        }
    }

    public ListNode? head;

    public LinkedList()
    {
        head = null;
    }

    public void AddNode(int value)
    {
        ListNode newNode = new ListNode(value);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            ListNode current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = newNode;
        }
    }

    public void RemoveNodes(int x)
    {
        while (head != null && head.val > x)
        {
            head = head.next;
        }

        ListNode? current = head;

        while (current != null && current.next != null)
        {
            if (current.next.val > x)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }
    }

    public void PrintList()
    {
        ListNode? current = head;
        while (current != null)
        {
            Console.Write(current.val + " ");
            current = current.next;
        }
        Console.WriteLine();
    }

}

class Program
{
    public static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();

        // Adding nodes
        linkedList.AddNode(10);
        linkedList.AddNode(5);
        linkedList.AddNode(12);
        linkedList.AddNode(7);
        linkedList.AddNode(3);
        linkedList.AddNode(9);
        linkedList.AddNode(10);

        Console.WriteLine("Original List:");
        linkedList.PrintList();

        linkedList.RemoveNodes(7);

        Console.WriteLine("Modified List:");
        linkedList.PrintList();
    }
}
