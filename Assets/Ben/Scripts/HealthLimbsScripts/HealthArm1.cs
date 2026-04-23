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

    public Sprite LDollForeArm;
    public Sprite LDollUpperArm;

    public Sprite LDollForeArmBD;
    public Sprite LDollUpperArmBD;

    public Sprite LDollForearmFD;
    public Sprite LDollUpperArmFD;

        public Sprite LDollForeArmSLV;
        public Sprite LDollUpperArmSLV;

    public float degredationRate = 0.09f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        canTakeDamage = true;
        walkScript = transform.parent.GetComponent<WalkScript>();

        LDollForeArm = Resources.Load<Sprite>("Limbs/NLimbs/Doll Forearm BACK");
        LDollUpperArm = Resources.Load<Sprite>("Limbs/NLimbs/Doll Upper Arm BACK");

        LDollForeArmBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Forearm BACK DAMAGED");
        LDollUpperArmBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Upper Arm BACK DAMAGED");

        LDollForearmFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Forearm BACK FULLY DAMAGED");
        LDollUpperArmFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Upper Arm BACK FULLY DAMAGED");

        LDollForeArmSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Forearm BACK SLV");
        LDollUpperArmSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Upper Arm BACK SLV");

    }

    // Update is called once per frame
    void Update()
    {
        if (health > 10)
        {
            DollForermL.GetComponent<SpriteRenderer>().sprite = LDollForeArmSLV;
            DollUpperArmL.GetComponent<SpriteRenderer>().sprite = LDollUpperArmSLV;
        }

        if (health > 5 && health <= 10)
        {
            DollForermL.GetComponent<SpriteRenderer>().sprite = LDollForeArm;
            DollUpperArmL.GetComponent<SpriteRenderer>().sprite = LDollUpperArm;
        }

        if (health <= 5 && health > 2)
        {
            DollForermL.GetComponent<SpriteRenderer>().sprite = LDollForeArmBD;
            DollUpperArmL.GetComponent<SpriteRenderer>().sprite = LDollUpperArmBD;
        }

        if (health <= 2)
        {
            DollForermL.GetComponent<SpriteRenderer>().sprite = LDollForearmFD;
            DollUpperArmL.GetComponent<SpriteRenderer>().sprite = LDollUpperArmFD;
        }

        if (health <= 0)
        {
           DollForermL.SetActive(false);
           DollUpperArmL.SetActive(false);
        }
        else if (health > 0)
        {
            DollForermL.SetActive(true);
            DollUpperArmL.SetActive(true);
        }

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
            DollForermL.SetActive(false);
            DollUpperArmL.SetActive(false);
        }
    }

    private IEnumerator ClimbDamage()
    {
        canTakeDamage = false;
        health -= degredationRate;
        healthBarArm1.UpdateHealth(degredationRate);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }

   
    
}
