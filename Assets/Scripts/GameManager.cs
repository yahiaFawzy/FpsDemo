using GenesisCreationTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] PlayerInput playerInput;


    public static GameManager instance;

    private void Awake()
    {
        instance = this;

        UnLockPlayerInput();

    }


    public void LockPlayerInput() {
            playerInput.EnaMouseInput = false;
            playerInput.EnableKeyBordInput = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
    }

    public void UnLockPlayerInput()
    {
        playerInput.EnaMouseInput = true;
        playerInput.EnableKeyBordInput = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LockPlayerMouseInput()
    {
        Cursor.lockState = CursorLockMode.Confined;
        playerInput.EnaMouseInput = false;
        Cursor.visible = true;
    }

   

}
