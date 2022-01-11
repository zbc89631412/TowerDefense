using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Sword")]
public class Sword : Item
{
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        ItemManager.instance.UseSword(damageModifier);
        RemoveFromItem();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
