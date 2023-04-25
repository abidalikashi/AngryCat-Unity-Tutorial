using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenImage : MonoBehaviour
{
    public Slider slider;
    public Image image;
    public float tweenTime;
    public Toggle toggle;

    public Color beginColor, endColor;

    public void Tween()
    {
        float changeValue = (slider != null) ? slider.value : Convert.ToInt32(toggle.isOn);
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, 0.1f, 1, tweenTime).setEasePunch().setOnUpdate(

            (value) =>
            {
                image.fillAmount = value;
                Debug.Log(changeValue);
                image.color = Color.Lerp(beginColor, endColor, changeValue);
            });
    }
}
