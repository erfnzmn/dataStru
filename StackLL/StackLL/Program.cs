using System;
using static StackLL.LinkedList;

internal class Program
{
    private Node top;

    public bool isempty()
    {
        if (top.head == null)
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
            top.InsertAtTheEnd(item);
        }
    }
    public void pop()
    {
        top.DeleteFromEnd();
    }
   
}