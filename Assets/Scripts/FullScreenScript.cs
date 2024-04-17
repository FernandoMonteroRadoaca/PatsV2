using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenScript : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }else
        {
            toggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
