using UnityEngine;

public class HealthArm1 : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarArm1 healthBarArm1;

    public GameObject DollForermL;
    public GameObject DollUpperArmL;

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
        healthBarArm1.UpdateHealth(amount);
        if (health <= 0)
        {
            Destroy(DollUpperArmL);
            Destroy(DollForermL);
        }
    }
}
