using UnityEngine;

public class HealthLeg : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarLegTest1 healthBar1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar1.UpdateHealth(amount);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
