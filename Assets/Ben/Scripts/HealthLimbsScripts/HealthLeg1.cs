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

    private bool canTakeDamage = true;

    private Sprite LDollLeg;
    private Sprite LDollLegThigh;

    private Sprite LDollLegBD;
    private Sprite LDollLegThighBD;

    private Sprite LDollLegFD;
    private Sprite LDollLegThighFD;

    private Sprite LDollLegSLV;
    private Sprite LDollLegThighSLV;

    public float degredationRate = 0.09f;
    public float runDegredationRate = 0.115f;    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        canTakeDamage = true;
        walkScript = transform.parent.GetComponent<WalkScript>();

        LDollLeg = Resources.Load<Sprite>("Limbs/NLimbs/Doll Leg BACK");
        LDollLegThigh = Resources.Load<Sprite>("Limbs/NLimbs/Doll Thigh BACK");

        LDollLegBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Leg BACK DAMAGED");
        LDollLegThighBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Thigh BACK DAMAGED");

        LDollLegFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Leg BACK FULLY DAMAGED");
        LDollLegThighFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Thigh BACK FULLY DAMAGED");

        LDollLegSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Leg BACK SLV");
        LDollLegThighSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Thigh BACK SLV");
    }

    // Update is called once per frame
    void Update()
    {

        if (health > 10)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = LDollLegSLV;
            DollLegThighL.GetComponent<SpriteRenderer>().sprite = LDollLegThighSLV;
        }

        if (health > 5 && health <= 10)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = LDollLeg;
            DollLegThighL.GetComponent<SpriteRenderer>().sprite = LDollLegThigh;
        }

        //Shows degredation sprites when helath is half
        if (health <= 5 && health > 2)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = LDollLegBD;
            DollLegThighL.GetComponent<SpriteRenderer>().sprite = LDollLegThighBD;
        }
        //Shows fully damaged sprites when health is very low
        if (health <= 2)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = LDollLegFD;
            DollLegThighL.GetComponent<SpriteRenderer>().sprite = LDollLegThighFD;
        }
        if (health <= 0)
        {
            DollLegL.SetActive(false);
            DollLegThighL.SetActive(false);
        }
        else if (health > 0)
        {
            DollLegL.SetActive(true);
            DollLegThighL.SetActive(true);
        }

        //Takes steady damage when Walking
        if (canTakeDamage == true && walkScript.canMove)
        {
            if (walkScript.PlayerDirection.x > 0 && walkScript.isGrounded() || walkScript.PlayerDirection.x < 0 && walkScript.isGrounded())
            {
                StartCoroutine(WalkDamage());
            }

            if (walkScript.PlayerDirection.x > 7 && walkScript.isGrounded() || walkScript.PlayerDirection.x < -7 && walkScript.isGrounded())
            {
                StartCoroutine(RunDamage());
            }
        }

        //Takes damage when Jumping
        if (Input.GetKeyDown(KeyCode.Space) && walkScript.isGrounded())
        {
            StartCoroutine(JumpDegredation());
        }

        //Damages Legs when climbing
        if (walkScript.isClimbingLeft() && canTakeDamage == true && walkScript.PlayerDirection.y > 0 || walkScript.isClimbingRight() && canTakeDamage == true && walkScript.PlayerDirection.y > 0)
        {
            StartCoroutine(ClimbDamage());
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBarLeg1.UpdateHealth(amount);
        if (health <= 0)
        {
            DollLegL.SetActive(false);
            DollLegThighL.SetActive(false);
        }
    }
    private IEnumerator WalkDamage()
    {
        canTakeDamage = false;
        health -= degredationRate;
        healthBarLeg1.UpdateHealth(degredationRate);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }

    private IEnumerator RunDamage()
    {
        canTakeDamage = false;
        health -= runDegredationRate;
        healthBarLeg1.UpdateHealth(runDegredationRate);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }

    private IEnumerator JumpDegredation()
    {
        canTakeDamage = false;
        health -= 0.35f;
        healthBarLeg1.UpdateHealth(0.35f);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }

    private IEnumerator ClimbDamage()
    {
        canTakeDamage = false;
        health -= degredationRate;
        healthBarLeg1.UpdateHealth(degredationRate);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }
}
