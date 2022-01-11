using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    CharacterStats myStat;
    public float attackSpeed = 1.0f;
    private float attackCoolDown;
    public float attackDelay = 0.8f;
    public event System.Action OnAttack;
    public bool inCombat { get; private set; }
    float lastAttackTime;
    public float combatCoolDown = 5.0f;
    CharacterStats opponentStats;
    // Start is called before the first frame update
    void Start()
    {
        myStat = GetComponent<CharacterStats>();
        inCombat = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        attackCoolDown -= Time.deltaTime;
        if (Time.time - lastAttackTime > combatCoolDown)
        {
            inCombat = false;
        }
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCoolDown <= 0)
        {
            opponentStats = targetStats;
            
            if(OnAttack != null)
            {
                OnAttack();
            }
            attackCoolDown = 1 / attackSpeed;
            lastAttackTime = Time.time;
            inCombat = true;
        }
   
    }

    

    public void AttackHit_AnimationEvent()
    {
        opponentStats.TakeDamage(myStat.damage.GetValue());
        if (opponentStats.currentHealth <= 0)
        {
            inCombat = false;
        }
    }
}
