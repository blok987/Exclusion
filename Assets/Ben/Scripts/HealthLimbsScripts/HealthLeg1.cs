using UnityEditor.VersionControl;
using UnityEngine;
using System.Collections;

public class HealthLeg1 : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarLegTest1 healthBarLeg1;

    public GameObject DollLegL;
    public GameObject DollLegThighL;

    private WalkScript walkScript;

    public bool canTakeDamage = true;

    public Sprite DollLegBD;

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
        //if (health <= 5)
        //{
        //    DollLegL.GetComponent<SpriteRenderer>().sprite = DollLegBD;
        //}
        
        //Takes steady damage when Walking
        if (canTakeDamage == true && walkScript.canMove)
        {
            if (walkScript.PlayerDirection.x > 0 && walkScript.isGrounded() || walkScript.PlayerDirection.x < 0 && walkScript.isGrounded())
            {
                StartCoroutine(WalkDamage());
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
        healthBarLeg1.UpdateHealth(amount);
        if (health <= 5)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = DollLegBD;
        }
        if (health <= 0)
        {
            Destroy(DollLegL);
            Destroy(DollLegThighL);
        }
    }
    private IEnumerator WalkDamage()
    {
        canTakeDamage = false;
        health -= 0.05f;
        healthBarLeg1.UpdateHealth(0.05f);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }

    private IEnumerator JumpDegredation()
    {
        canTakeDamage = false;
        health -= 0.3f;
        healthBarLeg1.UpdateHealth(0.3f);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }

    private IEnumerator ClimbDamage()
    {
        canTakeDamage = false;
        health -= 0.05f;
        healthBarLeg1.UpdateHealth(0.05f);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }
}
