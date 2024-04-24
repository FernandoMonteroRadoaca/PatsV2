using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool Pet1;
    public bool Pet2;

    public bool Pet3;

    private void Update()
    {
        if (Pet1 == false && Pet2 == false && Pet3 == false)
        {
            Pet1 = true;
        }

        Pet1 = PlayerPrefs.GetInt("Pet1Select") ==1;
        Pet2 = PlayerPrefs.GetInt("Pet2Select") ==1;
        Pet3 = PlayerPrefs.GetInt("Pet3Select") ==1;

    }

    public void Mascota1()
    {
        Pet1 = true;
        Pet2 = false;
        Pet3 = false;
        Guardar();
    }
    public void Mascota2()
    {
        Pet1 = false;
        Pet2 = true;
        Pet3 = false;
        Guardar();
    }

    public void Mascota3()
    {
        Pet1 = false;
        Pet2 = false;
        Pet3 = true;
        Guardar();
    }

    public void Guardar()
    {
        PlayerPrefs.SetInt("Pet1Select", Pet1 ? 1:0);
        PlayerPrefs.SetInt("Pet2Select", Pet2 ? 1:0);
        PlayerPrefs.SetInt("Pet3Select", Pet3 ? 1:0);
    }
}
