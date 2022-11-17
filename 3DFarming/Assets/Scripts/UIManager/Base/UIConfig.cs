using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UIConfig")]
public class UIConfig : ScriptableObject
{
    public UIConfigItem[] dataList;

    public GameObject GetPrefab(UIType uiType)
    {
        for (int i = 0; i < dataList.Length; i++)
        {
            UIConfigItem item = dataList[i];
            if (item.uiType == uiType && item.prefab != null)
            {
                return item.prefab;
            }
        }

        return null;
    }
}

[System.Serializable]
public struct UIConfigItem
{
    public UIType uiType;
    public GameObject prefab;
}

public enum UIType
{
    START=1,
    LOADING,
    Bag,
    
    SELECT_GATE = 100,
    GATE1 = 200,
    GATE2,
    GATE3,
    
    SUCCEED = 300,
    FAILD,
    
    Tips = 1000,
}