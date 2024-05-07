using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private GameObject MenuGameOver;
    private LoveBar loveBar;



    private void Start()
    {
        loveBar = GameObject.FindGameObjectWithTag("Player").GetComponent<LoveBar>();
        loveBar.DeathDog += ActivateMenu;
    }
    private void ActivateMenu(object sender, EventArgs e)
    {
        MenuGameOver.SetActive(true);
    }
    public void LoadStartMenu()
    {
        Time.timeScale = 1f;

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
