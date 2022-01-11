using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerStats playerStats;
    int damage_1 = 10;
    int damage_2 = 20;
    int defaultDamage = 5;
    [HideInInspector]
    public static int addDamage = 0;
    CharacterCombat combat;

    public void SetDamage_1(int damage)
    {
        damage_1 = damage;
    }
    public void SetDamage_2(int damage)
    {
        damage_2 = damage;
    }


    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("addDamge is " + addDamage);
            playerStats.damage.SetValue(damage_1+addDamage);
        }

         if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("addDamage is " + addDamage);
            playerStats.damage.SetValue(damage_2+addDamage);
        }
        if(!combat.inCombat)
        {
            //Debug.Log("add Damage is " + addDamage);
            playerStats.damage.SetValue(defaultDamage + addDamage);
        }
        
       
    }


}
