using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InicialMenuScript : MonoBehaviour
{
    public void Play()
    {
        if (PlayerPrefs.HasKey("SelectedDog"))
        {
            // Si hay un perrito guardado, cargar la escena principal del juego directamente
            SceneManager.LoadScene("StartRoom");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       
    }
    public void Exit()
    {
        Debug.Log("Exit...");
        Application.Quit();
    }

    
}
