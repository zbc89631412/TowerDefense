using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimator
{
    #region Singleton
    public static PlayerAnimator instance;
    public void Awake()
    {
        instance = this;
    }
    #endregion
    public List<AnimationClip> replacableAttackAnimation;
    int attackType ;
    public int count = 2;
    public List<AnimatorOverrideController> overrideController;
   
    protected override void Update()
    {
        base.Update();
        
        if (overrideController[CharacterCreation.instance.characterIndex] != null && animator != null && !hasOverrideController && !hasOverrideController)
        {
            hasOverrideController = true;
            animator.runtimeAnimatorController = overrideController[CharacterCreation.instance.characterIndex];
        }
        if (animator != null && !hasOverrideController)
        {
            overrideController[CharacterCreation.instance.characterIndex] = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = overrideController[CharacterCreation.instance.characterIndex];
            hasOverrideController = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            attackType = 0;
            overrideController[CharacterCreation.instance.characterIndex]
                [replacableAttackAnimation[CharacterCreation.instance.characterIndex].name] 
                = currentAttackAnimSet[CharacterCreation.instance.characterIndex*count+attackType];
                
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            attackType = 1;
            overrideController[CharacterCreation.instance.characterIndex]
                [replacableAttackAnimation[CharacterCreation.instance.characterIndex].name]
                = currentAttackAnimSet[CharacterCreation.instance.characterIndex * count + attackType];
            
        }
        if (!combat.inCombat)
        {
            overrideController[CharacterCreation.instance.characterIndex][replacableAttackAnimation[CharacterCreation.instance.characterIndex].name] = defaultAttackAnimSet[CharacterCreation.instance.characterIndex];
        }

        
    }
   


}

public enum AttackType { effectOne,effectTwo}
