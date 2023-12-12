using System;
using static StackLL.LinkedList;

internal class Program
{
    private Node top;
    Node stack = new Node(3);
    public bool isempty()
    {
        if (top == null)
            return true;
        else
            return false;
    }
    public void push(int item)
    {
        if (isempty())
        {
            return;
        }
        else
        {
            stack.InsertAtTheEnd(item);
        }
    }
    public void pop()
    {
        stack.DeleteFromEnd();
    }
   
}