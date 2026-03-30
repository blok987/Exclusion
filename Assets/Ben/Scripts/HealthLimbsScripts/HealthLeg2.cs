using UnityEngine;

public class HealthLeg2 : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarLegTest2 healthBarLeg2;

    public GameObject DollLegR;
    public GameObject DollLegThighR;

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
        healthBarLeg2.UpdateHealth(amount);
        if (health <= 0)
        {
            Destroy(DollLegR);
            Destroy(DollLegThighR);
        }
    }
}
