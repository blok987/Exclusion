using UnityEngine;
using System.Collections;

public class HealthLeg2 : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarLegTest2 healthBarLeg2;

    public GameObject DollLegR;
    public GameObject DollLegThighR;

    private bool canTakeDamage = true;

    private WalkScript walkScript;

    private Sprite RDollLeg;
    private Sprite RDollLegThigh;

    private Sprite RDollLegBD;
    private Sprite RDollLegThighBD;

    private Sprite RDollLegFD;
    private Sprite RDollLegThighFD;

    public float degredationRate = 0.09f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        walkScript = transform.parent.GetComponent<WalkScript>();

        RDollLeg = Resources.Load<Sprite>("Limbs/NLimbs/Doll Leg FRONT");
        RDollLegThigh = Resources.Load<Sprite>("Limbs/NLimbs/Doll Thigh FRONT");

        RDollLegBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Leg FRONT DAMAGED");
        RDollLegThighBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Thigh FRONT DAMAGED");

        RDollLegFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Leg FRONT FULLY DAMAGED");
        RDollLegThighFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Thigh FRONT FULLY DAMAGED");
    }

    // Update is called once per frame
    void Update()
    {
        #region Degredation Handling

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

        //Damages Legs when climbing
        if (walkScript.isClimbingLeft() && canTakeDamage == true && walkScript.PlayerDirection.y > 0 || walkScript.isClimbingRight() && canTakeDamage == true && walkScript.PlayerDirection.y > 0)
        {
            StartCoroutine(ClimbDamage());
        }
        #endregion

        if (health > 5)
        {
            DollLegR.GetComponent<SpriteRenderer>().sprite = RDollLeg;
            DollLegThighR.GetComponent<SpriteRenderer>().sprite = RDollLegThigh;
        }

        if (health <= 5 && health > 2)
        {
            DollLegR.GetComponent<SpriteRenderer>().sprite = RDollLegBD;
            DollLegThighR.GetComponent<SpriteRenderer>().sprite = RDollLegThighBD;
        }
        else if (health <= 2)
        {
            DollLegR.GetComponent<SpriteRenderer>().sprite = RDollLegFD;
            DollLegThighR.GetComponent<SpriteRenderer>().sprite = RDollLegThighFD;
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
        health -= 0.05f;
        healthBarLeg2.UpdateHealth(0.05f);
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

    private IEnumerator ClimbDamage()
    {
        canTakeDamage = false;
        health -= degredationRate;
        healthBarLeg2.UpdateHealth(degredationRate);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }
}
