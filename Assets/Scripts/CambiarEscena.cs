using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public int numEscena;
    // Start is called before the first frame update
    public void iniciar(){
        SceneManager.LoadScene(numEscena);
    }
}
