using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPerroRoom : MonoBehaviour
{
    public GameObject perro1;
    public GameObject perro2;
    public GameObject perro3;
    public int x;
    public int y;

    void Start()
    {
        Vector2 pos = new Vector2(x,y);
        string nombrePerro = PlayerPrefs.GetString("PerroSeleccionado");
        if(perro1.name == nombrePerro){
            Instantiate(perro1,pos,Quaternion.identity);
        }
         if(perro2.name == nombrePerro){
            Instantiate(perro2,pos,Quaternion.identity);
        }
         if(perro3.name == nombrePerro){
            Instantiate(perro3,pos,Quaternion.identity);
        }
        
    }
}
