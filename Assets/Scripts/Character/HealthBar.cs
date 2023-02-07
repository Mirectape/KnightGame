using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Character player;
    private float maxHealth;
    private float currentHealth;
    private Image healthBar;

    private void Awake()
    {
        healthBar = GetComponent<Image>();
        maxHealth = player.GetMaxHealth();
    }

    private void Update()
    {
        currentHealth = player.GetCurrentHealth();
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
