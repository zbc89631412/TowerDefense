using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Coin", menuName = "Inventory/Money")]
public class Money : Item
{
    public int money = 100;
    public override void Use()
    {
        base.Use();
        ItemManager.instance.UseMoney(money);
        RemoveFromItem();
    }
}
