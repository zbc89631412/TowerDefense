using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Accelerator")]
public class Accelerator : Item

{
    public int speedModifier = 10;

    public override void Use()
    {
        base.Use();
        ItemManager.instance.UseAccelerator(speedModifier);
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
