using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Toggle fullScreen;

    [SerializeField] private float defaultVolume = 50f;
    

    private const string FullScreenToggleKey = "FullScreenToggleState";

    void Start()
    {

       LoadSettings();
    }
    public void LoadSettings()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        if (PlayerPrefs.HasKey(FullScreenToggleKey))
        {
            bool isFullScreen = PlayerPrefs.GetInt(FullScreenToggleKey) == 1;
            fullScreen.isOn = isFullScreen;
        }
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            musicSlider.value = defaultVolume;
            PlayerPrefs.SetFloat("MusicVolume", defaultVolume);
        }
    }

    public void SetVolumePref()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
    public void SetFullScreenTogglePref()
    {
        // Guardar el estado del toggle de pantalla completa en PlayerPrefs
        PlayerPrefs.SetInt(FullScreenToggleKey, fullScreen.isOn ? 1 : 0);
        PlayerPrefs.Save(); // Guardar inmediatamente
    }


    // Este metodo lo utilizaremos en el caso de querer restaurar los valores mediante un button
    public void ResetDefaultValues()
    {
        PlayerPrefs.DeleteAll();
    }


}