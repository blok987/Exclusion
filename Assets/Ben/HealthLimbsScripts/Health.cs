using System.Collections;
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
        if (gameObject.transform.childCount <= 0)
        {
            health -= health;
            healthBar.UpdateHealth(health);
            
            
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
        
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
