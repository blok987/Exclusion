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
        
        if (canTakeDamage == true && walkScript.canMove)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                StartCoroutine(WaitForDamage());
            }
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
    private IEnumerator WaitForDamage()
    {
        canTakeDamage = false;
        health -= 0.3f;
        healthBarLeg1.UpdateHealth(0.3f);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;

    }
}
