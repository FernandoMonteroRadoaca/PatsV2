using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private GameObject MenuGameOver;
    private LoveBar loveBar;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource musicGlobal;



    private void Start()
    {
        loveBar = GameObject.FindGameObjectWithTag("Player").GetComponent<LoveBar>();
        loveBar.DeathDog += ActivateMenu;
    }
    private void ActivateMenu(object sender, EventArgs e)
    {
        MenuGameOver.SetActive(true);
        musicGlobal.Stop();
        musicSource.UnPause();
        Time.timeScale = 0f;

    }
    public void LoadStartMenu()
    {
        Time.timeScale = 1f;
        musicSource.UnPause();
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);


    }
    public void Close()
    {
        Debug.Log("Closing game");
        Application.Quit();
        Time.timeScale = 1f;

    }
    public void Retry()
    {
        SceneManager.LoadScene("StartRoom", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

}
