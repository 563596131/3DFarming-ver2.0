using System;
using System.Collections;
using System.Collections.Generic;
using BaseTools;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr Instance;
    public UIConfig uiConfig;
    public Transform parent;
    public UIBag uiBag;
    
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        EventMgr.Register<BoolEventData>(EventID.BAG_SELL, OnBoolEventData);
        EventMgr.Register<UITipsEventData>(EventID.UI_TIPS, OnUITipsEventData);
    }

    private void OnBoolEventData(BoolEventData eventData)
    {
        //Debug.Log(eventData.eventID);
        switch (eventData.eventID)
        {
            case EventID.BAG_SELL:
                uiBag.UpdateUIByEvent(new BoolEventData(true));
                break;
        }
    }

    private void OnStringEventData(StringEventData eventData)
    {
        
    }

    private void OnUITipsEventData(UITipsEventData eventData)
    {
        switch (eventData.eventID)
        {
            case EventID.UI_TIPS:
                CreateUIPrefab<UITips>(UIType.Tips, null, (tips =>
                {
                    tips.ShowTips(eventData.content, eventData.icon);
                }));
                break;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (uiBag.gameObject.activeSelf)
            {
                uiBag.gameObject.SetActive(false);
            }
            else
            {
                uiBag.UpdateUI(false);    
            }
        }
    }

    public void CreateUIPrefab<T>(UIType uiType, Transform parent, Action<T> action)
    {
        GameObject res = uiConfig.GetPrefab(uiType);
        if (res != null)
        {
            GameObject go = GameObject.Instantiate(res, parent);
            if (action != null)
            {
                action.Invoke(go.GetComponent<T>());
            }
        }
    }
}
