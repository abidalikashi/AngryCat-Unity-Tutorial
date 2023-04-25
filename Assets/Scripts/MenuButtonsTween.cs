using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonsTween : MonoBehaviour
{
    // Start is called before the first frame update
    public float tweenTime = 0.5f;

    public void AnimateSelectedButton()
    {
        LeanTween.scale(gameObject, new Vector3(1.5f, 1.5f), tweenTime).setEaseInCubic();
        Debug.Log("highlighted :" + gameObject.name);
    }


    public void AnimateDeSelectedButton()
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f), tweenTime).setEaseInCubic();
        Debug.Log("deselected :" + gameObject.name);

    }
}
