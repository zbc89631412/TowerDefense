
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;
    public Stat armor;
    bool hasAnimator = false;
    protected Animator animator;
    public int maxHealth =100;
    public int currentHealth  { get;protected set; }
    public event System.Action<int, int> OnHealthChanged;
    bool hasDead = false;
    void Awake()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (animator == null && !hasAnimator)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }
    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        //Debug.Log(transform.name + " take " + damage + " damage");
        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }
        if (currentHealth <= 0&&!hasDead)
        {
            Die();
            hasDead = true;
            currentHealth = 0;
        }
        
    }

    public void AddHealth()
    {

        if (currentHealth != maxHealth)
        {
            if ((maxHealth - currentHealth) < 5)
                currentHealth = maxHealth;
            else
                currentHealth += 5;
            Debug.Log("add health");
            if (OnHealthChanged != null)
            {
                Debug.Log("OnHealthChange");
                OnHealthChanged(maxHealth, currentHealth);
            }
        }

    }

    public virtual void Die()
    {
       // Debug.Log(transform.name + " die.");
       

    }
}
