using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class StackOfStrings
{
    private List<string> data = new List<string>();

    public bool IsEmpty()
    {
        return data.Count == 0;
    }

    public void Push(string newElement)
    {
        data.Add(newElement);
    }

    public string Pop()
    {
        string lastElement = string.Empty;

        if (!IsEmpty())
        {
            lastElement = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
        }
        return lastElement;
    }

    public string Peek()
    {
        string lastElement = string.Empty;

        if (!IsEmpty())
        {
            lastElement = data[data.Count - 1];
        }
        return lastElement;
    }

    
}

