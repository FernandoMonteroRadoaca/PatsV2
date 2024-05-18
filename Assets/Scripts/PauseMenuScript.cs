using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject musicManager;
    private bool pausedGame = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (pausedGame)
            {
                Reset();
            }
            else
            { 
                Pause();
            }
        }
    }
    public void Pause()
    {
        pausedGame = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);

    }

    public void Reset()
    {
        pausedGame = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void LoadStartMenu()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene("StartMenu",LoadSceneMode.Single);
        

    }

    public void Close() {
        Debug.Log("Closing game");
        Application.Quit();
    }

    

}
