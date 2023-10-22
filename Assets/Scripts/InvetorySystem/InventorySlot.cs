using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : ViewElement<InventoryItem>
{
    public TMPro.TMP_Text _itemNameTxt;
    public TMPro.TMP_Text _itemPriceTxt;
    public Image _itemIcon;   

    void Awake()
    {
        var slotButton = GetComponent<Button>();
        slotButton.onClick.AddListener(OnClicked);
    }

    private void ClearSlot()
    {
        _itemIcon.sprite = ResourcesManager.instance.imagesResources.emptySlotIcon;
        _itemPriceTxt.text = "";
        _itemNameTxt.text = "Empty";
    }

    public override void UpdateView(InventoryItem data)
    {    
        if (data != null)
        {
            _itemNameTxt.text  = data.itemName;
            _itemIcon.sprite   = data.itemIcon;
            _itemPriceTxt.text = data.itemPrice + "$";
        }
        else
        {
            ClearSlot();
        }
    }
}

