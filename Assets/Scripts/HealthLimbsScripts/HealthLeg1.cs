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
    public bool hasPlayedFD = false;
    public bool hasPlayedBD = false;
    public bool hasPlayedD = false;
    public bool hasPlayedSLV = false;

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

    AudioSource audioSource;

    public AudioClip Crack1;
    public AudioClip Crack2;
    public AudioClip Crack3;

    public AudioClip creak1;
    public AudioClip creak2;

    private ParticleSystem hitParticleL1;
    private ParticleSystem hitParticleL2;

    private ParticleSystem hitParticleSLV1;
    private ParticleSystem hitParticleSLV2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        canTakeDamage = true;
        hasPlayedSLV = true;
        walkScript = transform.parent.GetComponent<WalkScript>();

        LDollLeg = Resources.Load<Sprite>("Limbs/NLimbs/Doll Leg BACK");
        LDollLegThigh = Resources.Load<Sprite>("Limbs/NLimbs/Doll Thigh BACK");

        LDollLegBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Leg BACK DAMAGED");
        LDollLegThighBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Thigh BACK DAMAGED");

        LDollLegFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Leg BACK FULLY DAMAGED");
        LDollLegThighFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Thigh BACK FULLY DAMAGED");

        LDollLegSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Leg BACK SLV");
        LDollLegThighSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Thigh BACK SLV");

        audioSource = gameObject.GetComponentInParent<AudioSource>();

        Crack1 = Resources.Load<AudioClip>("Audio/SFX/crack1");
        Crack2 = Resources.Load<AudioClip>("Audio/SFX/crack2");
        Crack3 = Resources.Load<AudioClip>("Audio/SFX/crack3");

        creak1 = Resources.Load<AudioClip>("Audio/SFX/Creak1");
        creak2 = Resources.Load<AudioClip>("Audio/SFX/Creak2");

        //hitParticleL1 = GameObject.Find("bone_11").GetComponent<ParticleSystem>();
        //hitParticleL2 = GameObject.Find("bone_12").GetComponent<ParticleSystem>();
        
        //hitParticleSLV1 = GameObject.Find("DegredationParticleSLVLL1").GetComponent<ParticleSystem>();
        //hitParticleSLV2 = GameObject.Find("DegredationParticleSLVLL2").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 10)
        {
            maxHealth = 10;
        }

        if (health > 10)
        {
            hasPlayedSLV = false;
        }

        if (health > 5)
        {
            hasPlayedBD = false;
        }
        if (health > 2)
        {
            hasPlayedFD = false;
        }
        if (health > 10)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = LDollLegSLV;
            DollLegThighL.GetComponent<SpriteRenderer>().sprite = LDollLegThighSLV;
        }

        if (health > 5 && health <= 10)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = LDollLeg;
            DollLegThighL.GetComponent<SpriteRenderer>().sprite = LDollLegThigh;

                if (hasPlayedSLV == false)
                {
                    //hitParticleSLV1.Play();
                    //hitParticleSLV2.Play();
                    //int randomCrackSLV = Random.Range(1, 3);
                    //switch (randomCrackSLV)
                    //{
                    //    case 1:
                    //        audioSource.PlayOneShot(creak1);
                    //        break;
                    //    case 2:
                    //        audioSource.PlayOneShot(creak2);
                    //        break;
                        
                    //}
                    hasPlayedSLV = true;
            }
        }

        //Shows degredation sprites when helath is half
        if (health <= 5 && health > 2)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = LDollLegBD;
            DollLegThighL.GetComponent<SpriteRenderer>().sprite = LDollLegThighBD;

            if (hasPlayedBD == false)
            {
                //hitParticleL1.Play();
                //hitParticleL2.Play();
                int randomCrackBD = Random.Range(1, 2);
                switch (randomCrackBD)
                {
                    case 1:
                        audioSource.PlayOneShot(creak1);
                        break;
                    
                    //case 3:
                    //    audioSource.PlayOneShot(Crack3);
                    //    break;
                }
                hasPlayedBD = true;
            }
        }
        //Shows fully damaged sprites when health is very low
        if (health <= 2)
        {
            DollLegL.GetComponent<SpriteRenderer>().sprite = LDollLegFD;
            DollLegThighL.GetComponent<SpriteRenderer>().sprite = LDollLegThighFD;

            if (hasPlayedFD == false)
            {
                int randomCrackFD = Random.Range(1, 2);
                switch (randomCrackFD)
                {
                    case 1:
                        audioSource.PlayOneShot(creak1);
                        break;
                    
                    
                }
                hasPlayedFD = true;
            }
        }
        if (health <= 0)
        {
            DollLegL.SetActive(false);
            DollLegThighL.SetActive(false);

            if (hasPlayedD == false)
            {
                int randomCrackD = Random.Range(1, 4);
                switch (randomCrackD)
                {
                    case 1:
                        audioSource.PlayOneShot(Crack1);
                        break;
                    case 2:
                        audioSource.PlayOneShot(Crack2);
                        break;
                    case 3:
                        audioSource.PlayOneShot(Crack3);
                        break;
                }
                hasPlayedD = true;
            }
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
        if (Input.GetKeyDown(KeyCode.Space) && walkScript.isGrounded() && !walkScript.isClimbing && !walkScript.isCrippled)
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
