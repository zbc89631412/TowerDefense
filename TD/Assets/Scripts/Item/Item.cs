using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item") ]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefultItem = false;

    public virtual void Use()
    {
        //Debug.Log("Use "+ name);
    }

    public void RemoveFromItem()
    {
        Inventory.instance.RemoveItem(this);
    }
}
