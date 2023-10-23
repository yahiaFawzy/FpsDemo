using UnityEngine;

[System.Serializable]
public class InventoryItem

{
    public string itemName;
    public int itemPrice;
    public Sprite itemIcon;

    public static InventoryItem nullItem = new InventoryItem() { itemIcon = null, itemPrice = 0, itemName = null };
}