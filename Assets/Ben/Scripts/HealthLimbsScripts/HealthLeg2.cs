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

    public Sprite RDollLegBD;
    public Sprite RDollLegThighBD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        walkScript = transform.parent.GetComponent<WalkScript>();

        RDollLegBD = Resources.Load<Sprite>("Limbs/Doll Leg FRONT DAMAGED");
        RDollLegThighBD = Resources.Load<Sprite>("Limbs/Doll Thigh FRONT DAMAGED");
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

        if (health <= 5)
        {
            DollLegR.GetComponent<SpriteRenderer>().sprite = RDollLegBD;
            DollLegThighR.GetComponent<SpriteRenderer>().sprite = RDollLegThighBD;
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
        health -= 0.09f;
        healthBarLeg2.UpdateHealth(0.09f);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }
}
