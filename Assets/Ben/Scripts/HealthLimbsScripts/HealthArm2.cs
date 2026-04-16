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

    private Sprite RDollForeArm;
    private Sprite RDollUpperArm;

    private Sprite RDollForeArmBD;
    private Sprite RDollUpperArmBD;

    private Sprite RDollForearmFD;
    private Sprite RDollUpperArmFD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        canTakeDamage = true;
        walkScript = transform.parent.GetComponent<WalkScript>();

        RDollForeArm = Resources.Load<Sprite>("Limbs/NLimbs/Doll Forearm FRONT");
        RDollUpperArm = Resources.Load<Sprite>("Limbs/NLimbs/Doll Upper Arm FRONT");

        RDollForeArmBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Forearm FRONT DAMAGED");
        RDollUpperArmBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Upper Arm FRONT DAMAGED");

        RDollForearmFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Forearm FRONT FULLY DAMAGED");
        RDollUpperArmFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Upper Arm FRONT FULLY DAMAGED");
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 5)
        {
            DollForermR.GetComponent<SpriteRenderer>().sprite = RDollForeArm;
            DollUpperArmR.GetComponent<SpriteRenderer>().sprite = RDollUpperArm;
        }

        if (health <= 5 && health > 2)
        {
            DollForermR.GetComponent<SpriteRenderer>().sprite = RDollForeArmBD;
            DollUpperArmR.GetComponent<SpriteRenderer>().sprite = RDollUpperArmBD;
        }
        if (health <= 2)
        {
            DollForermR.GetComponent<SpriteRenderer>().sprite = RDollForearmFD;
            DollUpperArmR.GetComponent<SpriteRenderer>().sprite = RDollUpperArmFD;
        }

        if (health <= 0)
        {
            DollForermR.SetActive(false);
            DollUpperArmR.SetActive(false);
        }
        else if (health > 0)
        {
            DollForermR.SetActive(true);
            DollUpperArmR.SetActive(true);
        }

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
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }

    

}
