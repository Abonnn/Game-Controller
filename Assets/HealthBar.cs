using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;

    public void UpdateHealthBar(float health, float maxHealth)
    {
        float fillPercentage = health / maxHealth;

        // Debug log ini tetap berguna untuk mengecek nilai
        Debug.Log("Current Health: " + health + ", Max Health: " + maxHealth + ", Fill: " + fillPercentage);

        // Langkah 1: Cek dulu apakah nilainya valid. Jika tidak valid, hentikan fungsi.
        if (float.IsNaN(fillPercentage) || float.IsInfinity(fillPercentage))
        {
            Debug.LogError("Error: fillPercentage tidak valid!");
            return;
        }

        // Langkah 2: Jika nilainya valid (kode ini hanya akan berjalan jika tidak ada 'return' di atas),
        // maka update UI-nya.
        healthBar.fillAmount = fillPercentage;
    }
}