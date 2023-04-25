using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuTitleTween : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public AnimationCurve animationCurve;
    [SerializeField]
    public GameObject gameTitle;
    public float offsetY = 1;
    public float tweenTime = 1;
    void Start()
    {
        animateGameTitle(offsetY, gameTitle);

    }

    public void animateGameTitle(float offsetY, GameObject gameTitle)
    {
        LeanTween.moveY(gameTitle.GetComponent<RectTransform>(), gameTitle.transform.position.y - offsetY  , tweenTime).setEaseInOutCubic().setLoopPingPong();
    }

}
