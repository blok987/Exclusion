using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBarLegTest2 : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public HealthLeg2 healthLeg2;
    
    [SerializeField] private Image healthFill2;
    [SerializeField] private float fillSpeed;

    private void Update()
    {
        currentHealth = healthLeg2.health;
        UpdateHealthBar();
    }


    public void UpdateHealth(float amount)
    {
        currentHealth -= amount;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float targetFillAmount = currentHealth / maxHealth;
        //healthFill.fillAmount = targetFillAmount;
        healthFill2.DOFillAmount(targetFillAmount, fillSpeed);
    }
}
