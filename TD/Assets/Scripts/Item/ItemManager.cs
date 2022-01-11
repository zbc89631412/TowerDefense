using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region Singleton
    public static ItemManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject player;
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseMedicine()
    {
        Debug.Log("Use Medicine");
        playerStats.AddHealth();

    }
    public void UseMoney(int change)
    {
        Debug.Log("Use Money");
        MoneyManager.instance.ChangeMoney(change);
    }
    
    public void UseSword(int damageModifier)
    {
        PlayerAttack.addDamage = 10;
        StartCoroutine(ChangeDamageValue());
    }
    public void UseAccelerator(int speedModifier)
    {
        PlayerMotor.speed = speedModifier;
        StartCoroutine(ChangeSpeed());

    }
    IEnumerator ChangeSpeed()
    {

        //Debug.Log("print first");
        yield return new WaitForSeconds(5.0f);
        PlayerMotor.speed = 5;
       // Debug.Log(" after ten seconds speed is " + );
    }
    IEnumerator ChangeDamageValue()
    {

      //  Debug.Log("print first");
        yield return new WaitForSeconds(10.0f);
        PlayerAttack.addDamage = 0;
      //  Debug.Log(" after ten seconds addDamage is " + PlayerAttack.addDamage );
    }
}
