using System;
using System.Collections;
using System.Collections.Generic;
using BaseTools;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    private void Awake()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(OnClickEvent);
        }
    }

    public virtual void OnClickEvent()
    {
        if (SoundMgr.Instance != null)
        {
            SoundMgr.Instance.PlaySound(SoundType.BUTTON1);
        }
    }
}
