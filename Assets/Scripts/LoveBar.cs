using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveBar : MonoBehaviour
{
    public Image loveImage;

    public float actualLove;  //Make reference to our player script taht have a variable "love" inside
    public float maxLove;

   
    void Update()
    {
        loveImage.fillAmount = actualLove / maxLove;
    }

    //Todo , create metdo that increase love or deacrease 
}
