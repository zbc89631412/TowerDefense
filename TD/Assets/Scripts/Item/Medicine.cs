using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "medicine", menuName = "Inventory/Medicine")]
public class Medicine : Item
{
    public int health;

    public override void Use()
    {
        base.Use();
        ItemManager.instance.UseMedicine();
        RemoveFromItem();
       
    }

}
