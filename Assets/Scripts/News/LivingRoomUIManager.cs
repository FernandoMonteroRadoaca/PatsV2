using UnityEngine;
using UnityEngine.UI;

public class LivingRoomUIManager : MonoBehaviour
{
    public Button[] buttonsToShow;
    public Button[] buttonsToDisable;
    private ClickDog currentDog;

    private void Start()
    {
        SetButtonsActive(false); // Oculta los botones al principio
    
    }

    // Método para activar todos los botones
    public void ActivateButtons()
    {
        foreach (Button button in buttonsToDisable)
        {
            button.interactable = true;
        }
    }

    // Método para desactivar todos los botones
    public void DesactivateButtons()
    {
        foreach (Button button in buttonsToDisable)
        {
            button.interactable = false;
        }
    }

    // Método para activar o desactivar los botones
    public void SetButtonsActive(bool isActive)
    {
        foreach (var button in buttonsToShow)
        {
            button.gameObject.SetActive(isActive);
        }
    }
    public void ShowButtons(ClickDog dog){
        currentDog = dog;
        SetButtonsActive(true);
    }
    public void HideButtons(){
        SetButtonsActive(false);
    }
    public void OnBackButtonClicked(){
        if(currentDog != null){
            currentDog.MoveBack();
        }
    }
    public void DesactivateButtonsWthoutInventory()
    {
        foreach (Button button in buttonsToDisable)
        {   
            if(button.name != "FoodButton"){
                button.interactable = false;
            }
        }
    } 
}
