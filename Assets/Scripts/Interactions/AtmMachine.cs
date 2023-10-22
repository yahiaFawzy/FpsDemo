using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtmMachine : IteractableBase
{

    
    [SerializeField] GameObject atmUIRoot;

    public override void Interact()
    {
        ShowAtmMachineUI(true);
        GameManager.instance.LockPlayerMouseInput();

    }

    public override void ExitInteract()
    {
        ShowAtmMachineUI(false);
        GameManager.instance.UnLockPlayerInput();
    }

    private void ShowAtmMachineUI(bool status)
    {
        atmUIRoot.SetActive(status);
    }

   


}
