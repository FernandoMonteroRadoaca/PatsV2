using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel;
    public Button openPanelButton;
    public RawImage backgroundRawImage;
    public Animator dogAnimator;
    public float scrollSpeed = 0.1f;

    private Material backgroundMaterial;
    private Vector2 uvOffset = Vector2.zero;
    private string dogName;

    void Start()
    {
        openPanelButton.onClick.AddListener(OpenPanel);
        panel.SetActive(false); // Asegúrate de que el panel esté oculto al inicio.
        backgroundMaterial = backgroundRawImage.material;
        dogName = PlayerPrefs.GetString("SelectedDog");

        switch (dogName)
        {
            case "Dog":
                dogAnimator.SetBool("Dog", true);
                break;
            case "Lab":
                dogAnimator.SetBool("Lab", true);
                break;
            case "Pug":
                dogAnimator.SetBool("Pug", true);
                break;
            default:
                Debug.LogWarning("Dog name not recognized: " + dogName);
                break;
        }
    }

    void Update()
    {
        if (panel.activeSelf)
        {
            uvOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
            backgroundMaterial.SetTextureOffset("_MainTex", uvOffset);
        }
    }

    void OpenPanel()
    {
        panel.SetActive(true);
        Invoke("ClosePanel", 3f); // Cierra el panel después de 3 segundos.
    }

    void ClosePanel()
    {
        panel.SetActive(false);
    }
}