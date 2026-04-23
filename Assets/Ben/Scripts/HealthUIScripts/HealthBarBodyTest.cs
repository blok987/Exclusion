using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBarBodyTest : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Health health;
   
    [SerializeField] private Image healthFill;
    [SerializeField] private float fillSpeed;

    private void Update()
    {
        maxHealth = health.maxHealth;
        currentHealth = health.health;
        UpdateHealthBar();
    }


    public void UpdateHealth(float amount)
    {
        currentHealth -= amount;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float targetFillAmount = currentHealth / maxHealth;
        //healthFill.fillAmount = targetFillAmount;
        healthFill.DOFillAmount(targetFillAmount, fillSpeed);
    }
}
