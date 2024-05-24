using UnityEngine;

public class InstantiateDog : MonoBehaviour
{
    public GameObject[] dogPrefabs; // Assign the dog prefabs in the Inspector
    private GameObject instantiatedDog;
    void Start()
    {
        string selectedDogName = PlayerPrefs.GetString("SelectedDog");

        // Find the index of the selected dog in the prefab array
        int selectedDogIndex = -1;
        for (int i = 0; i < dogPrefabs.Length; i++)
        {
            if (dogPrefabs[i].name == selectedDogName)
            {
                selectedDogIndex = i;
                break;
            }
        }

        // If the selected dog is found, instantiate the corresponding prefab
        if (selectedDogIndex != -1)
        {
            GameObject dog = Instantiate(dogPrefabs[selectedDogIndex], transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Selected dog not found or corresponding prefab not assigned.");
        }
    }
    public GameObject GetInstantiatedDog()
    {
        return instantiatedDog;
    }
}
