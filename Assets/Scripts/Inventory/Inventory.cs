using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
      
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 10;

    public List<Item> items = new List<Item>();

    public Item itemOnHand { get; private set; }

    public void SetItemOnHand(Item item)
    {
        this.itemOnHand = item;
    }

    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {   
            if(items.Count >= space)
            {
                Debug.Log("Not enough inventory space");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke(); 
            }
            
        }

        return true;
    }
	
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }
}
