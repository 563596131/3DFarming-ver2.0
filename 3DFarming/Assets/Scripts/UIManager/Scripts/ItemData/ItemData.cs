using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData : ItemBaseData
{
    public ScriptableObject ExtraData;
    
    public int itemCount;
    public bool isEquip;
}