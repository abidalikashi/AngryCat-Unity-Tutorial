using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TweenText : MonoBehaviour
{
    public float tweenTime;
    public TextMeshProUGUI textMesh;

    public void Tween()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;
        LeanTween.scale(gameObject, Vector3.one * 1.5f, tweenTime).setEasePunch();
    }

}
