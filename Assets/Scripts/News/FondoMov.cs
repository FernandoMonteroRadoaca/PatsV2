using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FondoMov : MonoBehaviour
{
    // Variables públicas para asignar desde el Inspector
    public Renderer fondo;
    public GameObject[] prefabs;
    public Vector2 spawnPosition;
    public float timeToChangeScene = 10f; // Tiempo en segundos para cambiar de escena
    public string nextSceneName = "StartRoom"; // Nombre de la siguiente escena
    

    void Start()
    {
        StartCoroutine(ChangeSceneAfterTime(timeToChangeScene));
        // Obtener el nombre del objeto seleccionado desde PlayerPrefs
        string name = PlayerPrefs.GetString("SelectedDog");
        
        // Buscar el prefab que contiene el nombre
        GameObject selectedPrefab = null;
        foreach (GameObject prefab in prefabs)
        {
            if (prefab.name.Contains(name))
            {
                selectedPrefab = prefab;
                break;
            }
        }

        // Si encontramos un prefab que coincide, lo instanciamos
        if (selectedPrefab != null)
        {
            GameObject perro = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No se encontró un prefab que contenga el nombre: " + name);
        }

        // Iniciar la coroutine para cambiar de escena después de un tiempo
        
        
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.03f, 0f) * Time.deltaTime;
    }

    // Coroutine para cambiar de escena después de un tiempo
    IEnumerator ChangeSceneAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nextSceneName);
    }
}
