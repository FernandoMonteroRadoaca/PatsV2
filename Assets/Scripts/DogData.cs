using UnityEngine;

[System.Serializable]
public class DogData : MonoBehaviour
{
    public string skinName;

    public DogData(GameObject dog)
    {
        skinName = dog.name; // Suponemos que el nombre del GameObject representa el skin
    }
}
