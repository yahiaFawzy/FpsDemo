using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public  InventoryController playerInventory;
    public  InventoryController shopInventory;
    [Header("Trade Area")]
    [SerializeField] GameObject tradeArea;
    [SerializeField] Button sellButton;
    [SerializeField] Button buyButton;
    [Header("Headr Trade item")]
    [SerializeField] Image itemToTradeIcon;

    [SerializeField] Button exitButton;
    internal void SetShopData(InventoryDataBase dataBase)
    {
        shopInventory.inventoryData = dataBase;
    }

    [SerializeField] TMPro.TMP_Text itemToTradeName;
    [SerializeField] TMPro.TMP_Text itemToTradePrice;

    private int seletedItemIndex;
    private InventoryItem selectedItem;

    public static ShopMenu instance;

    [Header("inventory slots items")]
    [SerializeField] InventoryDataBase inventoryData;

    private void Awake()
    {
        instance = this;    
    }

    private void Start()
    {

        playerInventory.OnItemSelected = OnPlayerItemSelected;
        shopInventory.OnItemSelected = OnShopItemSelected;

        sellButton.onClick.AddListener(SellButtonHandler);
        buyButton.onClick.AddListener(BuyButtonHandler);
        exitButton.onClick.AddListener(ExitButton);
    }

    private void ExitButton()
    {
        GameManager.instance.UnLockPlayerInput();
        gameObject.SetActive(false);
    }

    private void SetItemDataToTrade(InventoryItem item, int index) {
        itemToTradeIcon.sprite = item.itemIcon;
        itemToTradeName.text = item.itemName;
        itemToTradePrice.text = item.itemPrice + "$";
        seletedItemIndex = index;
        selectedItem = item;
    }

    private void OnShopItemSelected(InventoryItem item,int index)
    {        
        if (item != null)
        {
            sellButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
            buyButton.interactable = item.itemPrice <= PlayerProfile.Cash;
            SetItemDataToTrade(item,index);
            tradeArea.SetActive(true);
        }
        else
        {
            tradeArea.SetActive(false);
        }
    }

    private void OnPlayerItemSelected(InventoryItem item,int index)
    {
        if (item != null)
        {
            sellButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
            SetItemDataToTrade(item,index);
            tradeArea.SetActive(true);
        }
        else
        {
            tradeArea.SetActive(false);
        }
    }

    private void SellButtonHandler()
    {
        //add to shop
        bool sucessProcess = shopInventory.AddItem(selectedItem);

        if (sucessProcess)
        {
            //remove for player
            selectedItem = playerInventory.RemoveItem(seletedItemIndex);
            PlayerProfile.Cash += selectedItem.itemPrice;
            GameMenu.instacne.UpdatePlayerCashUI(PlayerProfile.Cash);
            tradeArea.SetActive(false);
        }
    }

    private void BuyButtonHandler()
    {
        //add to player
        bool sucessProccess = playerInventory.AddItem(selectedItem);

        if (sucessProccess) Debug.Log("sucess");

        if (sucessProccess)
        {
            //remove from shop
            selectedItem = shopInventory.RemoveItem(seletedItemIndex);
            PlayerProfile.Cash -= selectedItem.itemPrice;
            GameMenu.instacne.UpdatePlayerCashUI(PlayerProfile.Cash);
            tradeArea.SetActive(false);
        }
    }
}
