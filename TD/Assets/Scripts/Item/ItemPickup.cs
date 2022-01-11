using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Pick up item" + item.name);
        bool wasPickedUp = Inventory.instance.AddItem(item);
        if (wasPickedUp)
            Destroy(gameObject);
       
    }
}
