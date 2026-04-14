using UnityEngine;
using System.Collections;

public class HealthArm1 : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarArm1 healthBarArm1;

    public GameObject DollForermL;
    public GameObject DollUpperArmL;

    private WalkScript walkScript;

    public bool canTakeDamage = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        canTakeDamage = true;
        walkScript = transform.parent.GetComponent<WalkScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkScript.isClimbingLeft() && canTakeDamage == true && walkScript.PlayerDirection.y > 0 || walkScript.isClimbingRight() && canTakeDamage == true && walkScript.PlayerDirection.y > 0)
        {
            StartCoroutine(ClimbDamage());
        }
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

    private IEnumerator ClimbDamage()
    {
        canTakeDamage = false;
        health -= 0.09f;
        healthBarArm1.UpdateHealth(0.09f);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }

   
    
}
