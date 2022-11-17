using System;
using System.Collections;
using System.Collections.Generic;
using BaseTools;
using UnityEngine;
using UnityEngine.UI;

public class UIBag : MonoBehaviour
{
    public GameObject itemTemp;
    public Button sellBtn;
    private List<UIBagItem> itemList = new List<UIBagItem>();

    private void Awake()
    {
        itemTemp.SetActive(false);
        sellBtn.onClick.AddListener(OnSellClick);
        // test
        // for (int i = 0; i < 3; i++)
        // {
        //     ItemMgr.Instance.AddItem(i+1, 34);
        // }
    }

    public void UpdateUIByEvent(BoolEventData eventData)
    {
        bool isSell = eventData.param;
        UpdateUI(isSell);
    }

    public void UpdateUI(bool isSell)
    {
        for (int i = itemList.Count; i < ItemMgr.Instance.currItemList.Count; i++)
        {
            GameObject go = GameObject.Instantiate(itemTemp,itemTemp.transform.parent);
            itemList.Add(go.GetComponent<UIBagItem>());
            go.SetActive(true);
        }

        for (int i = ItemMgr.Instance.currItemList.Count; i < itemList.Count; i++)
        {
            itemList[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < ItemMgr.Instance.currItemList.Count; i++)
        {
            UIBagItem uiItem = itemList[i];
            
            ItemData data = ItemMgr.Instance.currItemList[i];
            uiItem.UpdateItem(data, isSell);
            uiItem.gameObject.SetActive(true);
        }
        sellBtn.gameObject.SetActive(isSell);
        gameObject.SetActive(true);
    }
    

    private void OnSellClick()
    {
        int sell_cnt = 0;
        int sell_coin = 0;
        List<ItemData> sellList = new List<ItemData>();
        for (int i = 0; i < ItemMgr.Instance.currItemList.Count; i++)
        {
            UIBagItem uiItem = itemList[i];
            
            if (uiItem.sellToggle.isOn)
            {
                ItemData data = ItemMgr.Instance.currItemList[i];
                sellList.Add(data);
                sell_cnt+= data.itemCount;
                sell_coin += data.sellPrice * data.itemCount;
            }
        }

        if (sell_coin > 0)
        {
            string content = string.Format("total sell item {0}, get coin {1}. confirm sell?", sell_cnt, sell_coin);
            UIDlg.Instance.ShowUI(content, 2, (bool ok)=>{
                if (ok)
                {
                    for (int i = 0; i < sellList.Count; i++)
                    {
                        ItemData item = sellList[i];
                        ItemMgr.Instance.SubItem(item.itemId, item.itemCount);
                    }
                    UpdateUI(true);
                }
            });
        }
    }
}
