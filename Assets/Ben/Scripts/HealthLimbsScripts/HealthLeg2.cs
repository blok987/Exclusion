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
    public bool hasPlayedBD = false;
    public bool hasPlayedFD = false;
    public bool hasPlayedD = false;
    public bool hasPlayedSLV = false;

    private WalkScript walkScript;

    private Sprite RDollLeg;
    private Sprite RDollLegThigh;

    private Sprite RDollLegBD;
    private Sprite RDollLegThighBD;

    private Sprite RDollLegFD;
    private Sprite RDollLegThighFD;

    private Sprite RDollLegSLV;
    private Sprite RDollLegThighSLV;

    AudioSource audioSource;

    public AudioClip Crack1;
    public AudioClip Crack2;
    public AudioClip Crack3;

    public AudioClip creak1;
    public AudioClip creak2;

    private ParticleSystem hitParticleR1;
    private ParticleSystem hitParticleR2;

    private ParticleSystem hitParticleSLV1;
    private ParticleSystem hitParticleSLV2;

    public float degredationRate = 0.09f;
    public float runDegredationRate = 0.115f;

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

        RDollLegSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Leg FRONT SLV");
        RDollLegThighSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Thigh FRONT SLV");

        audioSource = gameObject.GetComponentInParent<AudioSource>();

        Crack1 = Resources.Load<AudioClip>("Audio/SFX/crack1");
        Crack2 = Resources.Load<AudioClip>("Audio/SFX/crack2");
        Crack3 = Resources.Load<AudioClip>("Audio/SFX/crack3");

        creak1 = Resources.Load<AudioClip>("Audio/SFX/Creak1");
        creak2 = Resources.Load<AudioClip>("Audio/SFX/Creak2");

        hitParticleR1 = GameObject.Find("bone_9").GetComponent<ParticleSystem>();
        hitParticleR2 = GameObject.Find("bone_10").GetComponent<ParticleSystem>();

        hitParticleSLV1 = GameObject.Find("DegredationParticleSLVRL1").GetComponent<ParticleSystem>();
        hitParticleSLV2 = GameObject.Find("DegredationParticleSLVRL2").GetComponent<ParticleSystem>();
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
                StartCoroutine(WalkDamage());
            }

            if (walkScript.PlayerDirection.x > 7 && walkScript.isGrounded() || walkScript.PlayerDirection.x < -7 && walkScript.isGrounded())
            {
                StartCoroutine(RunDamage());
            }
        }

        //Takes damage when Jumping
        if (Input.GetKeyDown(KeyCode.Space) && walkScript.isGrounded() && !walkScript.isCrippled && !walkScript.isClimbing)
        {
            StartCoroutine(JumpDegredation());
        }

        //Damages Legs when climbing
        if (walkScript.isClimbingLeft() && canTakeDamage == true && walkScript.PlayerDirection.y > 0 || walkScript.isClimbingRight() && canTakeDamage == true && walkScript.PlayerDirection.y > 0)
        {
            StartCoroutine(ClimbDamage());
        }
        #endregion
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 10)
        {
            maxHealth = 10;
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
            DollLegR.GetComponent<SpriteRenderer>().sprite = RDollLegSLV;
            DollLegThighR.GetComponent<SpriteRenderer>().sprite = RDollLegThighSLV;
            hasPlayedSLV = false;

        }

        if (health > 5 && health <= 10)
        {
            DollLegR.GetComponent<SpriteRenderer>().sprite = RDollLeg;
            DollLegThighR.GetComponent<SpriteRenderer>().sprite = RDollLegThigh;

            if (hasPlayedSLV == false)
            {
                hitParticleSLV1.Play();
                hitParticleSLV2.Play();
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

        if (health <= 5 && health > 2)
        {
            DollLegR.GetComponent<SpriteRenderer>().sprite = RDollLegBD;
            DollLegThighR.GetComponent<SpriteRenderer>().sprite = RDollLegThighBD;

            if (hasPlayedBD == false)
            {
                hitParticleR1.Play();
                hitParticleR2.Play();
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
        if (health <= 2)
        {
            DollLegR.GetComponent<SpriteRenderer>().sprite = RDollLegFD;
            DollLegThighR.GetComponent<SpriteRenderer>().sprite = RDollLegThighFD;

            if (hasPlayedFD == false)
            {
                hitParticleR1.Play();
                hitParticleR2.Play();
                int randomCrackFD = Random.Range(1, 2);
                switch (randomCrackFD)
                {
                    case 1:
                        audioSource.PlayOneShot(creak1);
                        break;
                    
                    //case 3:
                    //    audioSource.PlayOneShot(Crack3);
                    //    break;
                }
                hasPlayedFD = true;
            }
        }

        if (health <= 0)
        {
            DollLegR.SetActive(false);
            DollLegThighR.SetActive(false);

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
            DollLegR.SetActive(true);
            DollLegThighR.SetActive(true);
        }

        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBarLeg2.UpdateHealth(amount);
        if (health <= 0)
        {
            DollLegR.SetActive(false);
            DollLegThighR.SetActive(false);
        }
    }
    private IEnumerator WalkDamage()
    {
        canTakeDamage = false;
        health -= degredationRate;
        healthBarLeg2.UpdateHealth(degredationRate);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true; 
    }

    private IEnumerator RunDamage()
    {
        canTakeDamage = false;
        health -= runDegredationRate;
        healthBarLeg2.UpdateHealth(runDegredationRate);
        yield return new WaitForSeconds(0.6f);
        canTakeDamage = true;
    }
    private IEnumerator JumpDegredation()
    {
        canTakeDamage = false;
        health -= 0.35f;
        healthBarLeg2.UpdateHealth(0.35f);
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
