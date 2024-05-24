using UnityEngine;
using UnityEngine.UI;

public class LivingRoomUIManager : MonoBehaviour
{
    public Button[] buttonsToShow;

    private void Start()
    {
        SetButtonsActive(false); // Oculta los botones al principio
    }

    // Método para activar o desactivar los botones
    public void SetButtonsActive(bool isActive)
    {
        foreach (var button in buttonsToShow)
        {
            button.gameObject.SetActive(isActive);
        }
    }
}
