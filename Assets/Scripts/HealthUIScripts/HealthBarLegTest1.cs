using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBarLegTest1 : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public HealthLeg1 healthLeg1;

    [SerializeField] private Image healthFill2;
    [SerializeField] private float fillSpeed;


    private void Update()
    {
        maxHealth = healthLeg1.maxHealth;
        currentHealth = healthLeg1.health;
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
        healthFill2.DOFillAmount(targetFillAmount, fillSpeed);
    }
}
