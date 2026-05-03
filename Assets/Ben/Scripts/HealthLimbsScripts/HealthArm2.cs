using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;

public class HealthArm2 : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public HealthBarArm2 healthBarArm2;

    public GameObject DollForermR;
    public GameObject DollUpperArmR;

    private WalkScript walkScript;

    public bool canTakeDamage = true;
    public bool hasPlayedFD = false;
    public bool hasPlayedBD = false;

    public float degredationRate = 0.09f;

    private Sprite RDollForeArm;
    private Sprite RDollUpperArm;

    private Sprite RDollForeArmBD;
    private Sprite RDollUpperArmBD;

    private Sprite RDollForearmFD;
    private Sprite RDollUpperArmFD;

    private Sprite RDollForeArmSLV;
    private Sprite RDollUpperArmSLV;

    AudioSource audioSource;

    public AudioClip Crack1;
    public AudioClip Crack2;
    public AudioClip Crack3;




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

        RDollForeArmSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Forearm FRONT SLV");
        RDollUpperArmSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Upper Arm FRONT SLV");

        audioSource = gameObject.GetComponentInParent<AudioSource>();

        Crack1 = Resources.Load<AudioClip>("Audio/SFX/crack1");
        Crack2 = Resources.Load<AudioClip>("Audio/SFX/crack2");
        Crack3 = Resources.Load<AudioClip>("Audio/SFX/crack3");
    }

    // Update is called once per frame
    void Update()
    {

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
            DollForermR.GetComponent<SpriteRenderer>().sprite = RDollForeArmSLV;
            DollUpperArmR.GetComponent<SpriteRenderer>().sprite = RDollUpperArmSLV;
        }
        if (health > 5 && health <= 10)
        {
            DollForermR.GetComponent<SpriteRenderer>().sprite = RDollForeArm;
            DollUpperArmR.GetComponent<SpriteRenderer>().sprite = RDollUpperArm;
        }

        if (health <= 5 && health > 2)
        {
            DollForermR.GetComponent<SpriteRenderer>().sprite = RDollForeArmBD;
            DollUpperArmR.GetComponent<SpriteRenderer>().sprite = RDollUpperArmBD;

            if (hasPlayedBD == false)
            {
                int randomCrackBD = Random.Range(1, 4);
                switch (randomCrackBD)
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
                hasPlayedBD = true;
            }
        }
        if (health <= 2)
        {
            DollForermR.GetComponent<SpriteRenderer>().sprite = RDollForearmFD;
            DollUpperArmR.GetComponent<SpriteRenderer>().sprite = RDollUpperArmFD;

            if (hasPlayedFD == false)
            {
                int randomCrackFD = Random.Range(1, 4);
                switch (randomCrackFD)
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
                hasPlayedFD = true;
            }
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

        if (walkScript.isCrippled && canTakeDamage == true && walkScript.PlayerDirection.x > 0 || walkScript.isCrippled && canTakeDamage == true && walkScript.PlayerDirection.x < 0)
        {
            StartCoroutine(CrawlDamage());
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBarArm2.UpdateHealth(amount);
        if (health <= 0)
        {
            DollForermR.SetActive(false);
            DollUpperArmR.SetActive(false);

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

    private IEnumerator CrawlDamage()
    {
        canTakeDamage = false;
        health -= degredationRate;
        healthBarArm2.UpdateHealth(degredationRate);
        yield return new WaitForSeconds(0.5f);
        canTakeDamage = true;
    }

}
