using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public Slider affectionSlider;
    public Slider hungerSlider;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        moneyText.text = "" + GameManager.Instance.money;
        affectionSlider.value = GameManager.Instance.affection;
        hungerSlider.value = GameManager.Instance.hunger;
    }
}
