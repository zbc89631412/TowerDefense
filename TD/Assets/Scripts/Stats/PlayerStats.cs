﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(3);
        }
    }

    public void SetDamage(int newDamage)
    {
        
    }




    public override void Die()
    {
        base.Die();
        PlayerAnimator.instance.PlayDeathStatus();
        LastCanvas.gameIsOver = true;
        LastCanvas.isLost = false;
       
    }

}
