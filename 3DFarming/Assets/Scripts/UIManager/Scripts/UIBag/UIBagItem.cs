using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBagItem: UIPointEvent<UIBagItem>
{
    public UIItemBoundConfig config;

    public Image boundImage;

    public Image iconImage;
    public Text countText;

    public ItemData itemData;
    public bool isSelect;
    public Toggle sellToggle;
    public Text nameText;
    
    public void UpdateItem(ItemData itemData, bool isSell)
    {
        this.itemData = itemData;
        nameText.text = itemData.itemName;
        iconImage.sprite = itemData.itemIcon;
        countText.text = itemData.itemCount.ToString();
        sellToggle.gameObject.SetActive(isSell);
        if (isSell)
        {
            sellToggle.isOn = false;
        }
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
    }
    
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (onPointerExit != null)
        {
            onPointerExit.Invoke(this);
        }
    }
}
