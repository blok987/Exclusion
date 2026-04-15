using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class HealthArm2 : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarArm2 healthBarArm2;

    public GameObject DollForermR;
    public GameObject DollUpperArmR;

    private WalkScript walkScript;

    public bool canTakeDamage = true;

    public float degredationRate = 0.09f;

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
        healthBarArm2.UpdateHealth(amount);
        if (health <= 0)
        {
            Destroy(DollUpperArmR);
            Destroy(DollForermR);
            
        }
    }
    private IEnumerator ClimbDamage()
    {
        print("ClimbDamage");
        canTakeDamage = false;
        health -= degredationRate;
        healthBarArm2.UpdateHealth(degredationRate);
        yield return new WaitForSeconds(0.7f);
        canTakeDamage = true;
    }

    

}
