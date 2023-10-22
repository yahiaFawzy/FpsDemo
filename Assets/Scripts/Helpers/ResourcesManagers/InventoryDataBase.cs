using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resources Manager/inventory", fileName = "InventoryData", order = 2)]

public class InventoryDataBase : ScriptableObject
{
    [SerializeField] private InventoryItem[] items;

    public InventoryItem[] Items { get => items; }


    [HideInInspector] public InventoryItem[] _Items;

    private void OnEnable()
    {
        _Items = items;
    }

}