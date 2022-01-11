using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory is found");
        }
        instance = this;
    }
    #endregion
    public List<Item> items = new List<Item>();
    public int space = 20;
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    public bool AddItem(Item item)
    {
        if(!item.isDefultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
            if (OnItemChangedCallback != null)
                OnItemChangedCallback.Invoke();
        }
       return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
}
