using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemBase> slots;

    public void AddItem(ItemBase item)
    {
        Debug.Log("item item" + item.ItemName);
        slots.Add(item);
        foreach (var itemSlot in slots)
        {
            Debug.Log(" item masuk" + itemSlot.ItemName);
            // if (itemSlot.IsEmpty)
            // {
            //     itemSlot.AddItem(item);
            //     return;
            // }
        }
    }


}

public class ItemSlot
{
    public ItemBase item;

    public ItemBase Item => item;

    public ItemSlot(ItemBase item)
    {
        this.item = item;
    }
}


