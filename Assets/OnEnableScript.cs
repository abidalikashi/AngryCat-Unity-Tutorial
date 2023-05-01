using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnEnableScript : MonoBehaviour
{

    [SerializeField]
    public GameObject tmp;
    private TweenText scriptRef;
    private bool scriptRan = false;

    private void Start()
    {
        scriptRef = tmp.GetComponent<TweenText>();
        
    }

    private void OnEnable()
    {
        if (this.GetComponent<Canvas>().enabled == true)
        {
            scriptRef.TweenCubicUp();
            scriptRan = true;
        }
    }

    private void Update()
    {
     
        if (scriptRan == false)
        {
            OnEnable();
        }
        
    }
}
