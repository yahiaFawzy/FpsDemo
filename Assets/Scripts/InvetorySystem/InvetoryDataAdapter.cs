using UnityEngine;
using System;

public class InvetoryDataAdapter
{
    public Action<InventoryItem[]> OnInventoryDataUpdated;

    private InventoryItem[] inventoryItems;
    private ListClickedListener onListItemClikedListener;
    public ListClickedListener OnListItemClikedListener { get => onListItemClikedListener;}

    public InvetoryDataAdapter(InventoryDataBase inventoryData, Action<InventoryItem[]> onItemUpdated ,ListClickedListener onListItemClikedListener = null)
    {
        this.onListItemClikedListener = onListItemClikedListener;
        this.inventoryItems = inventoryData.Items;
        this.OnInventoryDataUpdated = onItemUpdated;
    }

    internal InventoryItem GetItem(int index)
    {
        return inventoryItems[index];
    }

    public bool AddItem(InventoryItem inventoryItem)
    {  

        int addIndex = inventoryItems.Length-1;

        if (inventoryItems[addIndex].itemIcon == null) {

            //shift to first free
            while (addIndex > 0&&inventoryItems[addIndex-1].itemIcon == null)
            {
                addIndex--;
            }

            inventoryItems[addIndex] = inventoryItem;
            OnInventoryDataUpdated?.Invoke(inventoryItems);
            return true;

        }
        else {
            return false;
        }

       
    }

    public InventoryItem RemoveItem(int removeIndex)
    {
        if (removeIndex < inventoryItems.Length)
        {
            InventoryItem item = inventoryItems[removeIndex];
            inventoryItems[removeIndex] = InventoryItem.nullItem;
            //shif null to end
            for (int i = removeIndex; i < inventoryItems.Length-1; i++) {
                inventoryItems[i] = inventoryItems[i + 1];
                inventoryItems[i + 1] = InventoryItem.nullItem;
            }

            OnInventoryDataUpdated?.Invoke(inventoryItems);
            return item;
        }
        else
        {
            Debug.Log("array out of bounds");
            return null;
        }
    }


   
   
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int itemPrice;
    public Sprite itemIcon;

    public static InventoryItem nullItem = new InventoryItem() { itemIcon = null, itemPrice = 0,itemName = null };
}