using UnityEngine;

public class HealthArm2 : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarArm2 healthBarArm2;

    public GameObject DollForermR;
    public GameObject DollUpperArmR;

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
        healthBarArm2.UpdateHealth(amount);
        if (health <= 0)
        {
            Destroy(DollUpperArmR);
            Destroy(DollForermR);
        }
    }
}
