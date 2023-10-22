using System;
using UnityEngine;
using UnityEngine.UI;
[DefaultExecutionOrder(100)]
public class InventoryController : MonoBehaviour
{
    InventoryAdapter<InventoryItem> inventoryAdapter;
    public Action<InventoryItem,int> OnItemSelected; 

    [Header("inventory ui")]
    [SerializeField] InventorySlot inventorySlotPrefab;
    [SerializeField] RectTransform inventoryListRoot;
    [SerializeField] Button nextButton;
    [SerializeField] Button prevuiosButton;
    [SerializeField] TMPro.TMP_Text pageTxt;


    [Header("inventort data")]
    [SerializeField] int inventoryNumOfPages = 3;
    [SerializeField] int inventoryNumOfItemPerPage = 9;

    [Header("inventory slots items")]
    public InventoryDataBase inventoryData;
    public InventoryAdapter<InventoryItem> InventoryAdapter { get => inventoryAdapter; set => inventoryAdapter = value; }

    private void OnEnable()
    {
        if (inventoryAdapter != null)
            inventoryAdapter.UpdateViews(inventoryData._Items);
    }

    public void Awake() {
        //list click
        ListClickedListener listClickedListener = new ListClickedListener(OnInventorySlotClicked);

        //adapter  
        inventoryAdapter = new InventoryAdapter<InventoryItem>(
            inventorySlotPrefab, inventoryListRoot, inventoryData._Items, inventoryNumOfPages, inventoryNumOfItemPerPage, currentPage: 1, listClickedListener);
        inventoryAdapter.CreateViews();

        //add button handlers
        nextButton.onClick.AddListener(OnNextButtonClicked);
        prevuiosButton.onClick.AddListener(OnPrevuiosButtonClicked);
    }  

    private void OnInventorySlotClicked(int index)
    {
        InventoryItem inventoryItem = GetItem(index);
        OnItemSelected?.Invoke(inventoryItem,index);
    }
    private void OnPrevuiosButtonClicked()
    {
       int page =  inventoryAdapter.OnPrevuisPageClicked();
       UpateCurrrentPageText(page);
    }
    private void OnNextButtonClicked()
    {
       int page =  inventoryAdapter.OnNextPageClicked();
       UpateCurrrentPageText(page);
    }
    void UpateCurrrentPageText(int page) {
        pageTxt.text = page + "/" + inventoryNumOfPages;
    }
    public bool AddItem(InventoryItem item)
    {
        //make sure there is empty slot
        var data = inventoryAdapter.Data;
        int inventorySize = inventoryNumOfPages * inventoryNumOfItemPerPage;
        if (data.Length >= inventorySize)
        {
            return false;
        }

        InventoryItem[] expandedArray = new InventoryItem[data.Length + 1];
        //copy old array refrences 
        for (int i = 0; i < data.Length; i++)
        {
            expandedArray[i] = data[i];
        }
        //add new item
        expandedArray[data.Length] = item;
        //save data 
        inventoryData._Items = expandedArray;
        //update views
        inventoryAdapter.UpdateViews(inventoryData._Items);
        

        return true;
    }
    public InventoryItem RemoveItem(int index)
    {
        var data = inventoryAdapter.Data;
        if (index > data.Length)
        {
            return null;
        }

        InventoryItem[] shrinkedArray = new InventoryItem[data.Length - 1];
        InventoryItem item = data[index];

        //copy old array refrences 
        for (int i = 0; i < data.Length; i++)
        {
            if (i < index)
                shrinkedArray[i] = data[i];
            else if (i > index)
                shrinkedArray[i - 1] = data[i];

        }

        //copy new array 
        data = shrinkedArray;
        //update data
        inventoryData._Items = data;
        //update views
        inventoryAdapter.UpdateViews(inventoryData._Items);

        return item;
    }
    public InventoryItem GetItem(int index)
    {
        var data = inventoryAdapter.Data;
        if (index < data.Length)
            return data[index];
        else
            return null;
    }

}
