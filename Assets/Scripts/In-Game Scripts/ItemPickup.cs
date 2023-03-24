using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Setting up item pickup
    public Item item;

    void PickupItem()
    {
        InventoryManager.instance.AddItem(item);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("colliding");
            PickupItem();
        }
    }
}
