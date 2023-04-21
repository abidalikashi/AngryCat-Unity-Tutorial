using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public AnimationCurve animationCurve;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void AnimateSelectedButton()
    {
        LeanTween.scale(gameObject, new Vector3(1.5f, 1.5f), 1.0f).setEase(animationCurve);
    }


    public void AnimateDeSelectedButton()
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f), 1.0f).setEase(animationCurve);
    }
}
