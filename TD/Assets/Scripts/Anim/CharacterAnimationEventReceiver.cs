using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventReceiver : MonoBehaviour
{
    public CharacterCombat combat;
    bool hasCombat = false;
    private void Update()
    {
        if (!hasCombat)
        {
            combat = transform.parent.gameObject.GetComponent<CharacterCombat>();
            hasCombat = true;
        }
    }
    public void AttackHitEvent()
    {
        //Debug.Log("AttackHitEvent");
        combat.AttackHit_AnimationEvent();
    }
}
