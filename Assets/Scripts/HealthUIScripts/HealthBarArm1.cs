using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBarArm1 : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public HealthArm1 healthArm1;

    [SerializeField] private Image healthFill3;
    [SerializeField] private float fillSpeed;

    private void Update()
    {
        maxHealth = healthArm1.maxHealth;
        currentHealth = healthArm1.health;
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
        healthFill3.DOFillAmount(targetFillAmount, fillSpeed);
    }
}
