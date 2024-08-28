using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;
    public ItemList itemList;

    private void Awake()
    {
        if (itemList.items.Contains(item))
        {
            Destroy(gameObject);
        }
    }

    public void AddToItemList()
    {
        itemList.items.Add(item);
    }
}
