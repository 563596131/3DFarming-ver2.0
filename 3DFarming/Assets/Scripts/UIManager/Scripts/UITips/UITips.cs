using System;
using System.Collections;
using System.Collections.Generic;
using BaseTools;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UITips : MonoBehaviour
{
    public Text text;
    public int speed = 10;
    public float duration = 3f;
    public Transform root;
    public Image image;
    public static void CreateTips(Sprite icon, string str)
    {
        UITipsEventData data = new UITipsEventData();
        data.icon = icon;
        data.content = str;
        EventMgr.Send<UITipsEventData>(EventID.UI_TIPS, data);
        //Object res = Resources.Load<GameObject>("UI/UITips");     
        // GameObject go = Instantiate(res) as GameObject;
        // // go.transform.SetParent(parent);
        // UITips tips = go.GetComponent<UITips>();
        // tips.ShowTips(str);
    }

    public void ShowTips(string str, Sprite icon = null)
    {
        text.text = str;
        if (icon == null)
        {
            image.gameObject.SetActive(false);
        }
        else
        {
            image.sprite = icon;
        }
    }

    private void Start()
    {
        GameObject.Destroy(gameObject,duration);
    }

    private void Update()
    {
        root.localPosition += Vector3.up * speed * Time.deltaTime;
    }
}
