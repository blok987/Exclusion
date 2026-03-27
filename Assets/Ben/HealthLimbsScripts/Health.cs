using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    private float damageForDeath;
    public HealthBarBodyTest healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount <= 0)
        {
            damageForDeath = health;
            health -= damageForDeath;
            healthBar.UpdateHealth(damageForDeath);
            
            
        }


        if (health <= 0)
        {
            
            StartCoroutine(Wait());
            
        }

    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.UpdateHealth(amount);
        
    }


    private IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
