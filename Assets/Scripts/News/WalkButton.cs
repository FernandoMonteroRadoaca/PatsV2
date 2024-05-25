using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WalkButton : MonoBehaviour
{
    public GameObject panel; // Asigna el panel en el Inspector
    public float displayTime = 2f; // Tiempo que el panel estará visible
    public Button button; // Asigna el botón en el Inspector

    private bool isPaused = false;
    private CanvasGroup panelCanvasGroup;
    private Button[] allButtons;

    void Start()
    {
        button.onClick.AddListener(ShowPanel);
        panel.SetActive(false); // Asegúrate de que el panel esté desactivado al inicio

        panelCanvasGroup = panel.GetComponent<CanvasGroup>();
        if (panelCanvasGroup == null)
        {
            panelCanvasGroup = panel.AddComponent<CanvasGroup>();
        }

        allButtons = FindObjectsOfType<Button>();
    }

    void ShowPanel()
    {
        StartCoroutine(DisplayPanel());
    }

    IEnumerator DisplayPanel()
    {
        panel.SetActive(true);
        PauseGame();

        // Desactiva la interactividad de todos los botones excepto el del panel
        foreach (Button btn in allButtons)
        {
            if (btn != button)
            {
                btn.interactable = false;
            }
        }

        yield return new WaitForSecondsRealtime(displayTime); // Usa WaitForSecondsRealtime para respetar la pausa

        panel.SetActive(false);
        ResumeGame();

        // Reactiva la interactividad de todos los botones
        foreach (Button btn in allButtons)
        {
            if (btn != button)
            {
                btn.interactable = true;
            }
        }
    }

    void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f; // Pausa el juego
            isPaused = true;
        }
    }

    void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // Reanuda el juego
            isPaused = false;
        }
    }
}
