using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : IteractableBase
{
    [SerializeField] ShopMenu shopMenu;
    [SerializeField] InventoryDataBase dataBase;
    public override void ExitInteract()
    {
        shopMenu.gameObject.SetActive(false);
        GameManager.instance.UnLockPlayerInput();
    }

    public override void Interact()
    {
        GameManager.instance.LockPlayerMouseInput();

        shopMenu.SetShopData(dataBase);
        shopMenu.gameObject.SetActive(true);
    }
  
}
