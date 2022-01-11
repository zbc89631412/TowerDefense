using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Equipment",menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public int damageModifier;
    public int speedModifier;
    public int defenseModifier;

    public override void Use()
    {
        base.Use();

    }
}
