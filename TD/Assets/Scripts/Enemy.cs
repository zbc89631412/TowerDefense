using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    CharacterStats myStats;
    PlayerManager playerManager;
    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        playerManager = PlayerManager.instance;
    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            
            
                playerCombat.Attack(myStats);
               // Debug.Log("Attack");           
        }
    }
}
