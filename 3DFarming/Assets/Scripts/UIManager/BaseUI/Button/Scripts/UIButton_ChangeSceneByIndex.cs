using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton_ChangeSceneByIndex : UIButton
{
    public int buildIndex;
    public override void OnClickEvent()
    {
        base.OnClickEvent();
        BaseTools.UITools.ChangeScene(buildIndex);
    }
}
