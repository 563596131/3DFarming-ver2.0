using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemBaseData
{
    public int itemId;
    public Sprite itemIcon;
    public string itemName;
    public string itemDesc;

    public int buyPrice;
    public int sellPrice;
    
    public ItemType itemType;
}