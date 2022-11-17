using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISellItem : UIPointEvent<UISellItem>
{
    public UIItemBoundConfig config;
    public Image boundImage;

    public Image iconImage;
    public Text countText;
    public Text priceText;
    public Button subBtn;
    public Button addBtn;
    public Button buyBtn;
    public InputField inputField;
    public Text totalPrice;
    
    public ItemData itemData;
    public bool isSelect;
    private int buyCount;
    
    private void Awake()
    {
        subBtn.onClick.AddListener(OnClickSub);
        addBtn.onClick.AddListener(OnClickAdd);
        buyBtn.onClick.AddListener(OnClickBuy);
        inputField.onEndEdit.AddListener(OnInputFieldEnd);
    }

    public void ShowItem(int itemId)
    {
        itemData = ItemMgr.Instance.itemConfig.CloneItemData(itemId);
        itemData.itemCount = 999999;

        iconImage.sprite = itemData.itemIcon;
        buyCount = 1;
        priceText.text = itemData.buyPrice.ToString();
        UpdateUI();
    }

    #region button event

    private void OnClickBuy()
    {
        ItemMgr.Instance.AddItem(itemData.itemId, buyCount);
        //itemData.itemCount -= buyCount;
        if (buyCount > itemData.itemCount)
        {
            buyCount = itemData.itemCount;
        }
        countText.text = itemData.itemCount.ToString();
        UpdateUI();
    }

    private void OnClickSub()
    {
        if (buyCount > 1)
        {
            buyCount--;
            UpdateUI();
        }
    }

    private void OnClickAdd()
    {
        if (buyCount < itemData.itemCount)
        {
            buyCount++;    
            UpdateUI();
        }
    }

    private void OnInputFieldEnd(string str)
    {
        int num;
        if (int.TryParse(str, out num))
        {
            if (num < 0)
            {
                num = 0;
            }
            else if (num > itemData.itemCount)
            {
                num = itemData.itemCount;
            }

            buyCount = num;
            UpdateUI();
        }
    }
    #endregion

    #region ui logic
    public void UpdateItem(ItemData itemData)
    {
        this.itemData = itemData;
        iconImage.sprite = itemData.itemIcon;
        countText.text = itemData.itemCount.ToString();
    }

    public void UpdateSelectStatus(bool isSelect)
    {
        if (itemData == null)
        {
            boundImage.sprite = isSelect ? config.emptySelected : config.empty;
        }
        else if (itemData.isEquip)
        {
            boundImage.sprite = isSelect ? config.filledEquippedSelected : config.filledEqupped;
        }else
        {
            boundImage.sprite = isSelect ? config.filledSelected : config.filled;
        }
    }

    public void UpdateUI()
    {
        inputField.text = buyCount.ToString();
        totalPrice.text = (buyCount * itemData.buyPrice).ToString();
    }

    #endregion

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onPointerClick != null)
        {
            onPointerClick.Invoke(this);    
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (onPointEnter != null)
        {
            onPointEnter.Invoke(this);
        }
        UIInfo.Instance.ShowUI(itemData.itemDesc, transform, Vector3.up*100);
    }
    
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (onPointerExit != null)
        {
            onPointerExit.Invoke(this);
        }
        UIInfo.Instance.HideUI();
    }
    
    
}
