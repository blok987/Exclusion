using UnityEngine;
using System.Collections;

public class HealthLeg2 : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarLegTest2 healthBarLeg2;

    public GameObject DollLegR;
    public GameObject DollLegThighR;

    public bool canTakeDamage = true;

    private WalkScript walkScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        walkScript = transform.parent.GetComponent<WalkScript>();
    }

    // Update is called once per frame
    void Update()
    {

        //Takes steady damage when Walking
        if (canTakeDamage == true && walkScript.canMove)
        {
            if (walkScript.PlayerDirection.x > 0 && walkScript.isGrounded() || walkScript.PlayerDirection.x < 0 && walkScript.isGrounded())
            {
                StartCoroutine(WaitForDamage());
            }
        }

        //Takes damage when Jumping
        if (Input.GetKeyDown(KeyCode.Space) && walkScript.isGrounded())
        {
            StartCoroutine(JumpDegredation());
        }
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
    private IEnumerator WaitForDamage()
    {
        canTakeDamage = false;
        health -= 0.2f;
        healthBarLeg2.UpdateHealth(0.2f);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true; 

    }
    private IEnumerator JumpDegredation()
    {
        canTakeDamage = false;
        health -= 0.5f;
        healthBarLeg2.UpdateHealth(0.5f);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }

}
