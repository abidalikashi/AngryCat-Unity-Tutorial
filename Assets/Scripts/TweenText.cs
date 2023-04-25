using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweenText : MonoBehaviour
{
    public float tweenTime;
    public TextMeshProUGUI textMesh;

    public void TweenPunch()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;
        LeanTween.scale(gameObject, Vector3.one *  1.5f, tweenTime).setEasePunch();
    }

    public void TweenCubicUp()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;
        LeanTween.scale(gameObject, Vector3.one * 1.5f, tweenTime).setEaseInOutCubic();
    }

    public void TweenCubicDown()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;
        LeanTween.scale(gameObject, Vector3.one * 1f, tweenTime).setEaseInOutCubic();
    }


}
