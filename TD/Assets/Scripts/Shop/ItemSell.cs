using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSell : MonoBehaviour
{
    public Item item;
    public int price;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BuyItem()
    {
        if (MoneyManager.instance.money < price)
        {
            Debug.Log("No money");
            return;
        }
        else
        {
            MoneyManager.instance.ChangeMoney(-price);
            Inventory.instance.AddItem(item);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
