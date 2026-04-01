using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    private float damageForDeath;

  //  private WalkScript walkScript;

   // public bool canTakeDamage = true;

    public HealthBarBodyTest healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
      //  canTakeDamage = true;
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

        //if (canTakeDamage == true && walkScript.canMove)
        //{
        //    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        //    {
        //        StartCoroutine(WaitForDamage());
        //    }
        //}

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

    //private IEnumerator WaitForDamage()
    //{
    //    canTakeDamage = false;
    //    health -= 0.3f;
    //    healthBar.UpdateHealth(0.3f);
    //    yield return new WaitForSeconds(0.6f);
    //    canTakeDamage = true;

    //}
}
