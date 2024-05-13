using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnumUsage : MonoBehaviour
{
    
   public enum ObjectsBag
    {
        LittleHunger,
        MediumHunger,
        BigHunger,
    };

    [SerializeField]  ObjectsBag objectsBag;

    LoveBar loveBar;


    public void UseObject()
    {
        loveBar = GameObject.FindObjectOfType<LoveBar>();

        switch (objectsBag)
        {
            case ObjectsBag.LittleHunger:
                loveBar.IncreaseHunger();
                Debug.Log("Restore little hunger");
                break;
            case ObjectsBag.MediumHunger:
                Debug.Log("Restore medium hunger");
                break;
            case ObjectsBag.BigHunger:
                Debug.Log("Restore big hunger");
                break;

        }
        Destroy(this.gameObject);
    }
}
