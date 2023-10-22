using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFadeInOut : MonoBehaviour
{
    public static ScreenFadeInOut instance;
    public RawImage fadeImage;
    [SerializeField] float fadeTime = 5;

    private void Awake()
    {
        instance = this;
    }

    public void FadeScreenEffect(Action OnComplete)
    {
        RawImage fadeImage = this.fadeImage;

        Color fadeONColor = new Vector4(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        Color fadeOffColor = new Vector4(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);

        //tween on
        DOTween.To(() => fadeImage.color, x => fadeImage.color = x, fadeONColor, fadeTime).OnComplete(() => {
            //switch 
            
            //tween off
            DOTween.To(() => fadeImage.color, x => fadeImage.color = x, fadeOffColor, fadeTime).OnComplete(() => {                
                OnComplete?.Invoke();
            });
        });
    }
}
