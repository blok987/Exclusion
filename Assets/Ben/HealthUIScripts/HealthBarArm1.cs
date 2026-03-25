using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBarArm1 : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    
    [SerializeField] private Image healthFill3;
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
        healthFill3.DOFillAmount(targetFillAmount, fillSpeed);
    }
}
