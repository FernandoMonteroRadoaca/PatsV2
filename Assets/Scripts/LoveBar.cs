using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class LoveBar : MonoBehaviour
{
    public Image loveImage;

    public float actualLove;  //Make reference to our player script taht have a variable "love" inside
    public float maxLove;

    public Image hungerImage;

    public float actualHunger;  //Make reference to our player script taht have a variable "hunger" inside
    public float maxHunger;

    public event EventHandler DeathDog;

    public TextMeshProUGUI increse20hearth;
    public TextMeshProUGUI increse10hearth;
    public TextMeshProUGUI increse30hearth;
    public TextMeshProUGUI increse5hearth;


    private void Start()
    {
        
        actualLove = maxLove * 0.9f;
        LoadMethod();
        // Call DecreaseLoveAndHunger method every 0.5 seconds for love and every second for hunger
        InvokeRepeating("DecreaseLove", 0f, 5.5f);
        InvokeRepeating("DecreaseHunger", 0f, 10f);
      


        // Subscribe the GameOver method to the DeathDog event
        DeathDog += GameOver;
    }

    private void DecreaseLove()
    {
        actualLove -= 2.9f; // Decrease love by 2 every 0.5 seconds
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
        actualHunger -= 5.1f; // Decrease hunger by 1 every second
        actualHunger = Mathf.Clamp(actualHunger, 0f, maxHunger); // Clamp the value between 0 and maxHunger
        UpdateHungerImage();
        if (actualHunger <= 0f)
        {
            // Trigger the DeathDog event
            OnDeathDog();
        }
    }

    public void DecreaseHungerBy(float amount){
        actualHunger -= amount;
        actualHunger = Mathf.Clamp(actualHunger, 0f, maxHunger);
        UpdateHungerImage();
    }
    public void IncreaseHungerBy30()
    {
        IncreaseHunger(30f);
        increse30hearth.gameObject.SetActive(true);
        StartCoroutine(ShowNotification30hunger());
    }
    IEnumerator ShowNotification30hunger()
    {
        increse30hearth.gameObject.SetActive(true);  // Activa el TextMeshPro
        yield return new WaitForSeconds(0.5f);  // Espera 1 segundo
        increse30hearth.gameObject.SetActive(false);  // Desactiva el TextMeshPro
    }
    IEnumerator ShowNotification10hunger()
    {
        increse10hearth.gameObject.SetActive(true);  // Activa el TextMeshPro
        yield return new WaitForSeconds(0.5f);  // Espera 1 segundo
        increse10hearth.gameObject.SetActive(false);  // Desactiva el TextMeshPro
    }
   IEnumerator ShowNotification20hunger()
    {
        increse20hearth.gameObject.SetActive(true);  // Activa el TextMeshPro
        yield return new WaitForSeconds(0.5f);  // Espera 1 segundo
        increse20hearth.gameObject.SetActive(false);  // Desactiva el TextMeshPro
    }
    IEnumerator ShowNotification5hunger()
    {
        increse5hearth.gameObject.SetActive(true);  // Activa el TextMeshPro
        yield return new WaitForSeconds(0.5f);  // Espera 1 segundo
        increse5hearth.gameObject.SetActive(false);  // Desactiva el TextMeshPro
    }

    public void IncreaseHungerBy10()
    {
        IncreaseHunger(10f);
        StartCoroutine(ShowNotification10hunger());
    }

    public void IncreaseHungerBy20()
    {
        IncreaseHunger(20f);
        increse20hearth.gameObject.SetActive(true);
        StartCoroutine (ShowNotification20hunger());

    }
    public void IncreaseHungerBy5()
    {
        IncreaseHunger(5f);
        increse5hearth.gameObject.SetActive(true);
        StartCoroutine(ShowNotification5hunger());
    }
   
    
    public void IncreaseLove(float amount){
        actualLove += amount;
        actualLove = Mathf.Clamp(actualLove, 0f, maxLove);
        UpdateLoveImage();
    }

    public void IncreaseHunger(float amount)
    {
        actualHunger += amount;
        actualHunger = Mathf.Clamp(actualHunger, 0f, maxHunger);
        UpdateHungerImage();
    }

    public void UpdateLoveImage()
    {
        loveImage.fillAmount = actualLove / maxLove; // Update the love UI image
        Debug.Log("Actual love ---> " + actualLove);
    }

   public void UpdateHungerImage()
    {
       
        Debug.Log( "Actual hunger ---> " + actualHunger);
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
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.G))
        {
            SaveMethod();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            LoadMethod();
        }
    }

    public void LoadMethod()
    {
        PlayerData playerData = SaveManager.LoadPlayerData();
        if (playerData != null)
        {
            actualLove = playerData.love;
            actualHunger = playerData.hunger;
            UpdateLoveImage();
            UpdateHungerImage();
            Debug.Log("Loaded data");
        }
        else
        {
            Debug.Log("No saved data found.");
        }
    }

    public void SaveMethod()
    {
        SaveManager.SavePlayerData(this, FindObjectOfType<UIShopManager>());
        Debug.Log("Data saved");
    }
}
