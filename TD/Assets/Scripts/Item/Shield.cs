using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Shield")]
public class Shield : Item
{
    public int defenseModifier;

    public override void Use()
    {
        base.Use();
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
