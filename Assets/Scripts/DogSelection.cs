using UnityEngine;
using UnityEngine.SceneManagement;

public class DogSelection : MonoBehaviour
{
    public GameObject perroPrefab; // Nombre del perro

    void OnMouseDown()
    {
        SceneManager.LoadScene("StartRoom"); // Cambiar a la escena StartRoom
        PlayerPrefs.SetString("PerroSeleccionado",gameObject.name);
    }
}
