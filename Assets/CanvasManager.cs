using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.enabled = true;
        optionsMenu.enabled = false;

    }

    public void pressOptions()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = true;
    }

    public void pressOptionsBack()
    {
        optionsMenu.enabled = false;
        mainMenu.enabled = true;
    }

}
