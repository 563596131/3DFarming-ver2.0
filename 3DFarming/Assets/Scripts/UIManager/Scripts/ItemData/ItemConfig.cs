using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    public List<ItemData> dataList;
    
    // get item data
    public ItemData GetItemData(int itemId)
    {
        ItemData data;
        for (int i = 0; i < dataList.Count; i++)
        {
            data = dataList[i];
            if (data == null) continue;
            if (data.itemId == itemId)
            {
                return data;
            }
        }

        Debug.LogError("canot find item data, item id: " + itemId);
        return null;
    }

    public ItemData CloneItemData(int itemId)
    {
        ItemData data = GetItemData(itemId);
        if (data == null) return null;


        ItemData item = new ItemData()
        {
            // base
            itemId = data.itemId,
            itemIcon = data.itemIcon,
            itemName = data.itemName,
            itemDesc = data.itemDesc,
            buyPrice = data.buyPrice,
            sellPrice = data.sellPrice,
            itemType = data.itemType,
            
            // 
            itemCount = data.itemCount,
            isEquip = data.isEquip,
            
        };
        return item;
    }
}

public enum ItemType
{
    Normal = 0,
    Seed,
    //Cost = 1, // 消耗品
    //Equip = 2, // 装备
}