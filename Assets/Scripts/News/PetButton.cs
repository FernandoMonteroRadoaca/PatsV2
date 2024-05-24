using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetButton : MonoBehaviour
{
     public Texture2D handCursor;
     private bool canClick = true;
    public void OnPetButtonClicked(){
        if(canClick){
            Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
            estaAcariciando();
            canClick = false;
        }
        
    }
    void estaAcariciando(){}
}
