using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;


    public GameObject normalHealthBar;
    public GameObject bossHealthBar;
    public Slider slider; // Can barý için slider kullanýyoruz
    public Slider bossSlider;
    public Image fillImage; // Dolum Image’ý
    public Image bossFillImage;
    //public float healthForBar;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void SetMaxHealth(int health)
    {
        //fillImage.fillAmount = health / healthForBar;

        slider.maxValue = health;
        bossSlider.maxValue = health;
        slider.value = health;
        bossSlider.value = health;

        fillImage.color = Color.green; // Maksimum saðlýkta yeþil renk
        bossFillImage.color = Color.green;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        bossSlider.value = health;
        //fillImage.fillAmount = health / healthForBar;

        // Can yüzdesine göre renk deðiþtirme
        if (health > slider.maxValue * 0.5f || health > bossSlider.maxValue * 0.5f)
        {
            fillImage.color = Color.green;
            bossFillImage.color = Color.green;
        }
        else if (health > slider.maxValue * 0.25f || health > slider.maxValue * 0.25f)
        {
            fillImage.color = Color.yellow;
            bossFillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.red;
            bossFillImage.color = Color.red;
        }
    }

    public void ChangeToBossHealthBar()
    {
        normalHealthBar.SetActive(false);
        bossHealthBar.SetActive(true);
    }
    public void ChangeToNormalHealthBar()
    {
        normalHealthBar.SetActive(true);
        bossHealthBar.SetActive(false);
    }
}
