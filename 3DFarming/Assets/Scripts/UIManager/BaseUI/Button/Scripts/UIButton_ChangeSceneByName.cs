using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton_ChangeSceneByName : UIButton
{
    public string buildName;
    public override void OnClickEvent()
    {
        base.OnClickEvent();
        BaseTools.UITools.ChangeScene(buildName);
    }
}
