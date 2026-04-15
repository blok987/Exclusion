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

    private Sprite LDollLegBD;
    private Sprite LDollLegThighBD;

    private Sprite LDollLegFD;
    private Sprite LDollLegThighFD;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        canTakeDamage = true;
        walkScript = transform.parent.GetComponent<WalkScript>();

        LDollLegBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Leg BACK DAMAGED");
        LDollLegThighBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Thigh BACK DAMAGED");

        LDollLegFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Leg BACK FULLY DAMAGED");
        LDollLegThighFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Thigh BACK FULLY DAMAGED");
    }

    // Update is called once per frame
    void Update()
    {
        //Shows degredation sprites when helath is half
        if (health <= 5 && health > 2)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = LDollLegBD;
            DollLegThighL.GetComponent<SpriteRenderer>().sprite = LDollLegThighBD;
        }
        //Shows fully damaged sprites when health is very low
        else if (health <= 2)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = LDollLegFD;
            DollLegThighL.GetComponent<SpriteRenderer>().sprite = LDollLegThighFD;
        }

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
        health -= 0.09f;
        healthBarLeg1.UpdateHealth(0.09f);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }
}
