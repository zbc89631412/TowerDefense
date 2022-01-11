using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    Animator animator;
    bool hasAnimator = false;
    float delayTime = 4;
    int lifeValue = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null&&!hasAnimator)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    public override void Die()
    {
        base.Die();
        GetComponent<EnemyAnimator>().PlayDeathStatus();
        Destroy(gameObject);
        MoneyManager.instance.ChangeMoney(lifeValue);
        //StartCoroutine(WaitAnimationPlay(delayTime));
       
    }
/*
    IEnumerator WaitAnimationPlay(float time)
    {
        //Debug.Log("WaitAnimationPlay");
        //animator.SetTrigger("enemyDeath");
        //yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }*/
}
