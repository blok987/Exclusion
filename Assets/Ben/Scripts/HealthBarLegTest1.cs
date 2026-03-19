using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBarLegTest1 : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private HealthLeg health;
    [SerializeField] private Image healthFill;
    [SerializeField] private float fillSpeed;

    void Start()
    {
        maxHealth = health.maxHealth;
        currentHealth = maxHealth;
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
