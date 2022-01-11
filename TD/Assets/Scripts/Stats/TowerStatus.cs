using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatus : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        base.Die();
        LastCanvas.instance.count++;
        Debug.Log("Tower Die");
        Debug.Log("count is " + LastCanvas.instance.count);
        Destroy(gameObject);
    }
}
