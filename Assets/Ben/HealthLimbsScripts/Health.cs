using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarBodyTest healthBar;

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
        healthBar.UpdateHealth(amount);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
