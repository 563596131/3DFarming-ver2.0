using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BaseTools;
public class ItemMgr : MonoBehaviour
{
    public static ItemMgr Instance;
    public ItemConfig itemConfig;
    public List<ItemData> currItemList = new List<ItemData>();

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region curr item data

    public ItemData GetItem(int itemId)
    {
        ItemData item;
        for (int i = 0; i < currItemList.Count; i++)
        {
            item = currItemList[i];
            if (item.itemId == itemId)
            {
                return item;
            }
        }

        return null;
    }
    
    
    public void AddItem(int itemId, int count)
    {
        ItemData item = GetItem(itemId);
        if (item == null)
        {
            item = itemConfig.CloneItemData(itemId);
            if (item != null)
            {
                item.itemCount = count;
                currItemList.Add(item);
            }
        }
        else
        {
            item.itemCount += count;
        }

        if (item != null)
        {
            string str = string.Format("{0} +{1}", item.itemName, count);
            UITips.CreateTips(item.itemIcon, str);

            EventMgr.Send<ItemEventData>(EventID.ADD_ITEM, new ItemEventData(item));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemId"></param>
    /// <param name="count"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public bool SubItem(int itemId, int count, UnityAction<ItemData, string> action = null)
    {
        ItemData item = GetItem(itemId);
        if (item != null)
        {
            if (count > item.itemCount)
            {
                if (action != null)
                {
                    action.Invoke(item, string.Format("cost item faild, itemId:{0}, count{1}", item.itemId, count));
                }
                return false;
            }
            else
            {
                item.itemCount -= count;
                
                string str = string.Format("{0} -{1}", item.itemName, count);
                UITips.CreateTips(item.itemIcon, str);
                
                EventMgr.Send<ItemEventData>(EventID.REMOVE_ITEM, new ItemEventData(item));
                
                if (item.itemCount == 0)
                {
                    currItemList.Remove(item);
                }

                if (action != null)
                {
                    action.Invoke(item, string.Format("{0} {1}", item.itemName, count));
                }

                return true;
            }
        }

        if (action != null)
        {
            action.Invoke(null, string.Format("cost item faild, None itemId:{0}, count{1}", item.itemId, count));
        }
        return false;
    }

    private void RemoveItem(int itemId)
    {
        ItemData item = GetItem(itemId);
        if (item != null)
        {
            currItemList.Remove(item);
        }
    }
    
    #endregion
    #region item config


    #endregion
    
}
