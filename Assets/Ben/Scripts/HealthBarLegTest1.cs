using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBarLegTest1 : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    
    [SerializeField] private Image healthFill2;
    [SerializeField] private float fillSpeed;

    

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
