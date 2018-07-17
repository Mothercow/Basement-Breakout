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

    public bool PC1;
    public bool PC2;

    public int space = 10;
    public GameObject paperChange;
    public GameObject paperChange2;
    public Item docAndClip;
    public Item docAndClip2;
    public Item doubleClip;
    public Item paperClip;
    public Item paperClip2;

    Item thisItem;
    Item thisItem2;

    bool hasDoubleClip = false;
    public static bool hasChangedDoc1 = false;
    public static bool hasChangedDoc2 = false;

    public List<Item> items = new List<Item>();

    public Item itemOnHand { get; private set; }

    void Update()
    {
        if(ItemPickup.hasPaperclip == true && hasChangedDoc1 == false)
        {
            thisItem = docAndClip; 
            thisItem.inspectGameObject = paperChange;
            docAndClip = thisItem;
            hasChangedDoc1 = true;
        }

        if(ItemPickup.hasPaperclip2 == true && hasChangedDoc2 == false)
        {
            thisItem2 = docAndClip2;
            thisItem2.inspectGameObject = paperChange2;
            docAndClip2 = thisItem2;
            hasChangedDoc2 = true;
        }

        if(ItemPickup.hasPaperclip == true && ItemPickup.hasPaperclip2 == true && hasDoubleClip == false)
        {
            Add(doubleClip);
            Remove(paperClip);
            Remove(paperClip2);
            hasDoubleClip = true;
        }

    }

    public void SetItemOnHand(Item item)
    {
        this.itemOnHand = item;
    }

    public bool Add(Item item)
    {
        if (item.name == "Paperclip")
        {
            PC1 = true;
        }
        else if (item.name == "Paperclip2")
        {
            PC2 = true;
        }

        if (!item.isDefaultItem)
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
