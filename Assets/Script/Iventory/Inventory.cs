using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // [SerializeField] private GameObject inventoryUI;
    [SerializeField]  List<ItemBase> slots;

    public void LoadItem()
    {
        if (slots != null)
        {
            foreach (ItemBase item in slots)
            {
                transform.GetChild(item.IndexNumber).gameObject.SetActive(true);
                // if (item.Item != null) {
                //     item.Item.SetActive(true);
                //     Debug.Log(item.ItemName);
                // }
            }
        }

    }

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


