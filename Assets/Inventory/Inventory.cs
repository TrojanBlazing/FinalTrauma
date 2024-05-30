using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    
    private int itemCount;

    public event EventHandler OnItemListChange;
    List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChange?.Invoke(this,EventArgs.Empty);
        //Debug.Log(item.Type);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
        OnItemListChange?.Invoke(item,EventArgs.Empty);
    }
}

