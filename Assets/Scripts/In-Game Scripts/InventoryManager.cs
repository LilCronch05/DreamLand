using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_InventorySlots;

    public List<Item> items = new List<Item>();


    public void MoveItem(Item item)
    {
        // Move item to another inventory
        // with drag and drop
        if (item != null)
        {
            items.Add(item);
            item.transform.SetParent(this.transform);
            item.transform.position = this.transform.position;
        }

        
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
