using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Interactable
{
    CharacterStats towerStats;
    PlayerManager playerManager;
    private void Start()
    {
        towerStats = GetComponent<CharacterStats>();
        playerManager = PlayerManager.instance;
    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(towerStats);
            // Debug.Log("Attack");           
        }
    }
}
