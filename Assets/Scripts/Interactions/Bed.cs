using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : IteractableBase
{
    public override void ExitInteract()
    {

    }

    public override void Interact()
    {
        ScreenFadeInOut.instance.FadeScreenEffect(OnFadeDone);
        GameManager.instance.LockPlayerInput();
    }

    private void OnFadeDone()
    {
        //+ banck account balance by 10
        PlayerProfile.accountBalace += PlayerProfile.accountBalace / 10;
        Debug.Log("on fade done" + PlayerProfile.accountBalace);

        GameManager.instance.UnLockPlayerInput();

    }
}
