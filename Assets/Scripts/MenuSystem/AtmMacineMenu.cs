using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtmMacineMenu : MonoBehaviour
{
    public static AtmMacineMenu instance;

    [SerializeField] TMPro.TMP_Text accountBalanceTxt;
    [SerializeField] Button depositeButton;
    [SerializeField] Button witdrawButton;

    [SerializeField] TMPro.TMP_Text processCashTxt;

    [SerializeField] Slider slider;
    [SerializeField] Button exitButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        depositeButton.onClick.AddListener(DepositeHandler);
        witdrawButton.onClick.AddListener(WithDrawHandler);
        witdrawButton.onClick.AddListener(ExitHandler);

        slider.onValueChanged.AddListener(OnMoneyAmoutSliderChange);
    }

    private void OnMoneyAmoutSliderChange(float arg0)
    {
        processCashTxt.text = (int)(arg0 * PlayerProfile.accountBalace)+"";
    }

  

    private void ExitHandler()
    {
        GameManager.instance.UnLockPlayerInput();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        UpateAccoutBalaneText(PlayerProfile.accountBalace);   
    }


    void UpateAccoutBalaneText(int balance) {
        accountBalanceTxt.text = "Balance : " + balance + "$";
    }

    public void DepositeHandler()
    {
        int cashToDeposite = int.Parse(processCashTxt.text);
        int oldCash = PlayerProfile.Cash;

        if (oldCash >= cashToDeposite)
        {
            PlayerProfile.accountBalace += cashToDeposite;


            //update atm
            UpateAccoutBalaneText(PlayerProfile.accountBalace);         

            //update player cash
            PlayerProfile.Cash = oldCash - cashToDeposite;
            GameMenu.instacne.UpdatePlayerCashUI(PlayerProfile.Cash);
        }

    }

    public void WithDrawHandler()
    {
        int cashToWithdraw = int.Parse(processCashTxt.text);

        if (PlayerProfile.accountBalace >= cashToWithdraw)
        {
            PlayerProfile.accountBalace -= cashToWithdraw;
            //update atm
            UpateAccoutBalaneText(PlayerProfile.accountBalace);

            //update player cash
            PlayerProfile.Cash += cashToWithdraw;

            GameMenu.instacne.UpdatePlayerCashUI(PlayerProfile.Cash);

        }
    }


}
