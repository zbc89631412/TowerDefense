using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : CharacterAnimator
{
    
    public AnimatorOverrideController overrideController;
    public AnimationClip replacableAttackAnimation;
    protected override void Update()
    {
        base.Update();
        if (overrideController != null && animator != null && !hasOverrideController && !hasOverrideController)
        {
            hasOverrideController = true;
            animator.runtimeAnimatorController = overrideController;
        }
        if (animator != null && !hasOverrideController)
        {
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = overrideController;
            hasOverrideController = true;
        }
    }

    protected override void OnAttack()
    {
        base.OnAttack();

         int attackIndex = Random.Range(0, currentAttackAnimSet.Length);

        overrideController[replacableAttackAnimation.name] = currentAttackAnimSet[attackIndex];
    }
}
