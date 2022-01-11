using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    #region Singleton
    public static MoneyManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    
    public int money = 100;
    public Text moneyText;
    public void ChangeMoney(int change)
    {
        //Debug.Log("change is " + change);
        money += change;
        //Debug.Log("Money is " + money);
        moneyText.text = "￥"+money;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
