using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag
{
    private List<string> _items;

    public Bag(string[] items)
    {
        _items = new List<string>(items);
    }

    public bool CheckReady(string[] requiredItems)
    {
        int count = requiredItems.Length;

        for (int i = 0; i < count; i++)
        {
            if (_items.Contains(requiredItems[i]) == false)
            {
                return false;
            }
        }

        return true;
    }
}
