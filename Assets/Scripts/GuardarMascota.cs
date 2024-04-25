using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool perro1;
    public bool perro2;
    public bool perro3;

    public void SeleccionPerro1(){
        perro1 = true;
        perro2 = false;
        perro3 = false;
    }
    public void SeleccionPerro2(){
        perro2 = true;
        perro1 = false;
        perro3 = false;
    }
    public void SeleccionPerro3(){
        perro3 = true;
        perro2 = false;
        perro1 = false;
    }

    public void Guardar(){
        PlayerPrefs.SetInt("Perro1Select",perro1 ? 1 : 0);
        PlayerPrefs.SetInt("Perro2Select",perro2 ? 1 : 0);
        PlayerPrefs.SetInt("Perro3Select",perro3 ? 1 : 0);
    }
}
