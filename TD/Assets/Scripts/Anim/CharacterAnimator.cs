using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterAnimator : MonoBehaviour
{
    
    NavMeshAgent agent;
    protected Animator animator;
    public float locomotionAnimationSmoothTime =0.1f;
    protected CharacterCombat combat;

    
    //public Dictionary<AnimatorOverrideController, int> overrideController;
        public AnimationClip[] defaultAttackAnimSet;
        public AnimationClip[] currentAttackAnimSet;
    //public List<AnimatorOverrideController> overrideController;
    bool hasList = false;

    protected bool hasOverrideController = false;
    // Start is called before the first frame update
    protected virtual void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        // animator = GetComponentInChildren<Animator>();
        combat.OnAttack += OnAttack;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        if(animator==null)
            animator = GetComponentInChildren<Animator>();
        
        //Debug.Log("animator name " + animator.name);
        float speedPercent = agent.velocity.magnitude / agent.speed;
        if (animator != null)
            animator.SetFloat("speedPercent1", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
        //Debug.Log("speedPercent " + speedPercent);
        animator.SetBool("inCombat", combat.inCombat);
       /* if (overrideControllerList != null && !hasList)
        {
            hasList = true;
            overrideController = overrideControllerList.ToArray();
        }*/
        /*
        if (overrideController != null&& animator != null&&!hasOverrideController&&!hasOverrideController)
        {
            hasOverrideController = true;
            animator.runtimeAnimatorController = overrideController;
        }
        if(animator!=null&&!hasOverrideController)
        {
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = overrideController;
            hasOverrideController = true;
        }*/

        
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("attack");
    }

    public virtual void PlayDeathStatus()
    {
        animator.SetTrigger("isDead");
        //animator.SetTrigger("isEnded");

    }


}
