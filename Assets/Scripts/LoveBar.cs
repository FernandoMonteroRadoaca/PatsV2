using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoveBar : MonoBehaviour
{
    public Image loveImage;

    public float actualLove;  //Make reference to our player script taht have a variable "love" inside
    public float maxLove;

    public Image hungerImage;

    public float actualHunger;  //Make reference to our player script taht have a variable "hunger" inside
    public float maxHunger;

    public event EventHandler DeathDog;

    private void Start()
    {
        actualLove = maxLove * 0.9f;
        // Call DecreaseLoveAndHunger method every 0.5 seconds for love and every second for hunger
        InvokeRepeating("DecreaseLove", 0f, 5.5f);
        InvokeRepeating("DecreaseHunger", 0f, 10f);

        // Subscribe the GameOver method to the DeathDog event
        DeathDog += GameOver;
    }

    private void DecreaseLove()
    {
        actualLove -= 0.9f; // Decrease love by 2 every 0.5 seconds
        actualLove = Mathf.Clamp(actualLove, 0f, maxLove); // Clamp the value between 0 and maxLove
        UpdateLoveImage();
        if (actualLove <= 0f)
        {
            // Trigger the DeathDog event
            OnDeathDog();
        }
    }

    private void DecreaseHunger()
    {
        actualHunger -= 10.1f; // Decrease hunger by 1 every second
        actualHunger = Mathf.Clamp(actualHunger, 0f, maxHunger); // Clamp the value between 0 and maxHunger
        UpdateHungerImage();
        if (actualHunger <= 0f)
        {
            // Trigger the DeathDog event
            OnDeathDog();
        }
    }
    public void IncreaseHungerBy30()
    {
        IncreaseHunger(30f);
    }

    public void IncreaseHungerBy10()
    {
        IncreaseHunger(10f);
    }

    public void IncreaseHungerBy20()
    {
        IncreaseHunger(20f);
    }

    public void IncreaseHunger(float amount)
    {
        actualHunger += amount;
        actualHunger = Mathf.Clamp(actualHunger, 0f, maxHunger);
        UpdateHungerImage();
    }

    private void UpdateLoveImage()
    {
        loveImage.fillAmount = actualLove / maxLove; // Update the love UI image
    }

    private void UpdateHungerImage()
    {
        Debug.Log("Update");
        Debug.Log(actualHunger);
        hungerImage.fillAmount = actualHunger / maxHunger; // Update the hunger UI image
    }

    // Method to trigger the DeathDog event
    protected virtual void OnDeathDog()
    {
        DeathDog?.Invoke(this, EventArgs.Empty);
    }

    // Method to handle game over
    private void GameOver(object sender, EventArgs e)
    {
       
        
    }
}
