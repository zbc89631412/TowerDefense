﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public GameObject inventoryUI;
    public Transform itemsParent;
    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

       

    }

    void UpdateUI()
    {
        //Debug.Log("UPDATING UI");
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
