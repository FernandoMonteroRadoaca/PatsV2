using UnityEngine;

public class InstanciarPerrito : MonoBehaviour
{
    public GameObject[] prefabsPerritos; // Asigna los prefabs de los perritos en el Inspector

    void Start()
    {
        string nombrePerritoSeleccionado = PlayerPrefs.GetString("PerritoSeleccionado");





        // Guardar el nombre del perrito seleccionado en PlayerData
        // Guardar el nombre del perrito seleccionado en PlayerPrefs
        PlayerPrefs.SetString("SelectedDog", nombrePerritoSeleccionado);
        PlayerPrefs.Save();

        // Busca el índice del perrito seleccionado en el array de prefabs
        int indicePerritoSeleccionado = -1;
        for (int i = 0; i < prefabsPerritos.Length; i++)
        {
            if (prefabsPerritos[i].name == nombrePerritoSeleccionado)
            {
                indicePerritoSeleccionado = i;
                break;
            }
        }

        // Si se encuentra el perrito seleccionado, instancia el prefab correspondiente
        if (indicePerritoSeleccionado != -1)
        {
            GameObject perrito = Instantiate(prefabsPerritos[indicePerritoSeleccionado], transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Perrito seleccionado no encontrado o prefab correspondiente no asignado.");
        }
    }
}
