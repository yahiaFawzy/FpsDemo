using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    [SerializeField] TMPro.TMP_Text cashTxt; 
    public static GameMenu instacne;

    [Header("Animation")]
    public Button inventoryActiveButton;
    public RectTransform inventoryRoot;
    [SerializeField] float invetoryShowTime;



    private void Awake()
    {
        instacne = this;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowHideInventoryAnimation();
        }    
    }


    private void Start()
    {
        //update cash
        UpdatePlayerCashUI(PlayerProfile.Cash);

        //hande active button
        inventoryActiveButton.onClick.AddListener(ShowHideInventoryAnimation);
    }

    public void UpdatePlayerCashUI(int cash) {        
        cashTxt.text = cash+"$";
    }

    private void ShowHideInventoryAnimation()
    {
        int targetScale = inventoryRoot.localScale.x == 1 ? 0 : 1;
          inventoryRoot.gameObject.SetActive(true);
        inventoryRoot.DOScale(new Vector3(1, 1, 1) * targetScale, invetoryShowTime).OnComplete(()=> { 
          inventoryRoot.gameObject.SetActive(targetScale==1);
        });


    }

}
