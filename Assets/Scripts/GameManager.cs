using DG.Tweening;
using GenesisCreationTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] PlayerInput playerInput;
    [SerializeField] GameObject controllersMenuRoot;

    public bool playerControllersIsLocked = false;
    public static GameManager instance;



    private void Awake()
    {
        instance = this;

        UnLockPlayerInput();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerControllersIsLocked == false)
        {
            ShowControllerMenu(!controllersMenuRoot.activeInHierarchy);
        }
    }

    public void ShowControllerMenu(bool status) {
        ShowHideControllersMenu();

        if (status)
            LockPlayerInput();
        else
            UnLockPlayerInput();
    }

    private void ShowHideControllersMenu()
    {
        int targetScale = controllersMenuRoot.transform.localScale.x == 1 ? 0 : 1;
        controllersMenuRoot.gameObject.SetActive(true);
        controllersMenuRoot.transform.DOScale(new Vector3(1, 1, 1) * targetScale, 0.2f).OnComplete(() => {
            controllersMenuRoot.gameObject.SetActive(targetScale == 1);
        });


    }



    public void LockPlayerInput() {
        playerControllersIsLocked = true;
            playerInput.EnaMouseInput = false;
            playerInput.EnableKeyBordInput = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
    }

    public void UnLockPlayerInput()
    {
        playerControllersIsLocked = false;
        playerInput.EnaMouseInput = true;
        playerInput.EnableKeyBordInput = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LockPlayerMouseInput()
    {
        playerControllersIsLocked = true;
        Cursor.lockState = CursorLockMode.Confined;
        playerInput.EnaMouseInput = false;
        Cursor.visible = true;
    }

   

}
