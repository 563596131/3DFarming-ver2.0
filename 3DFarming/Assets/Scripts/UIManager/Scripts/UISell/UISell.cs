using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UISell : MonoBehaviour
{
    public GameObject tempItem;

    public ItemType sellType;

    public UISellItem uiSellItem;

    public GameObject uiSellItemObj;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ItemMgr.Instance.itemConfig.dataList.Count; i++)
        {
            ItemData data = ItemMgr.Instance.itemConfig.dataList[i];
            if (data.itemType == sellType)
            {
                GameObject go = GameObject.Instantiate(tempItem,tempItem.transform.parent);
                SellItem sellItem = new SellItem();
                sellItem.onClickAction = OnClickItem;
                sellItem.data = data;
                
                Button btn = go.GetComponent<Button>();
                btn.onClick.AddListener(sellItem.OnClick);

                go.transform.Find("ImageIcon").GetComponent<Image>().sprite = data.itemIcon;
                
                go.SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        uiSellItemObj.SetActive(false);
    }

    private void OnClickItem(ItemData data)
    {
        uiSellItem.ShowItem(data.itemId);
        uiSellItemObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public class  SellItem
    {
        public ItemData data;
        public UnityAction<ItemData> onClickAction;
        public void OnClick()
        {
            onClickAction.Invoke(data);
        }
    }
}
