using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEventData
{
    public int eventID;
}

public class BoolEventData:BaseEventData
{
    public bool param;

    public BoolEventData(bool param)
    {
        this.param = param;
    }
}


public class IntEventData:BaseEventData
{
    public int param;

    public IntEventData(int param)
    {
        this.param = param;
    }
}

public class StringEventData:BaseEventData
{
    public string param;

    public StringEventData(string param)
    {
        this.param = param;
    }
}

public class UITipsEventData : BaseEventData
{
    public Sprite icon;
    public string content;
}

public class ItemEventData : BaseEventData
{
    public ItemData param;

    public ItemEventData(ItemData data)
    {
        this.param = data;
    }
}