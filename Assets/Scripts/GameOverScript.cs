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



    private void Start()
    {
        loveBar = GameObject.FindGameObjectWithTag("Player").GetComponent<LoveBar>();
        loveBar.DeathDog += ActivateMenu;
    }
    private void ActivateMenu(object sender, EventArgs e)
    {
        MenuGameOver.SetActive(true);
        musicSource.UnPause();

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
    }
    public void Retry()
    {
        SceneManager.LoadScene("StartRoom", LoadSceneMode.Single);
    }

}
