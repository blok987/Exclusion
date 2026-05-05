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

    public bool hasPlayedBD = false;  
    public bool hasPlayedFD = false;
    public bool hasPlayedD = false;

    public Sprite LDollForeArm;
    public Sprite LDollUpperArm;

    public Sprite LDollForeArmBD;
    public Sprite LDollUpperArmBD;

    public Sprite LDollForearmFD;
    public Sprite LDollUpperArmFD;

        public Sprite LDollForeArmSLV;
        public Sprite LDollUpperArmSLV;

    public float degredationRate = 0.09f;

    AudioSource audioSource;

    public AudioClip Crack1;
    public AudioClip Crack2;
    public AudioClip Crack3;

    public AudioClip creak1;
    public AudioClip creak2;

    private ParticleSystem hitParticleL1;
    private ParticleSystem hitParticleL2;

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

        audioSource = gameObject.GetComponentInParent<AudioSource>();

        Crack1 = Resources.Load<AudioClip>("Audio/SFX/crack1");
        Crack2 = Resources.Load<AudioClip>("Audio/SFX/crack2");
        Crack3 = Resources.Load<AudioClip>("Audio/SFX/crack3");

        creak1 = Resources.Load<AudioClip>("Audio/SFX/Creak1");
        creak2 = Resources.Load<AudioClip>("Audio/SFX/Creak2");

        //hitParticleL1 = GameObject.Find("bone_7").GetComponent<ParticleSystem>();
        //hitParticleL2 = GameObject.Find("bone_8").GetComponent<ParticleSystem>();

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

        if (health > 5)
        {
            hasPlayedBD = false;
        }
        if (health > 2)
        {
            hasPlayedFD = false;
        }
        if (health > 0)
        {
            hasPlayedD = false;
        }

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

        if (health <= 2)
        {
            DollForermL.GetComponent<SpriteRenderer>().sprite = LDollForearmFD;
            DollUpperArmL.GetComponent<SpriteRenderer>().sprite = LDollUpperArmFD;

            if (hasPlayedFD == false)
            {
                //hitParticleL1.Play();
                //hitParticleL2.Play();
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
           DollForermL.SetActive(false);
           DollUpperArmL.SetActive(false);
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
            DollForermL.SetActive(true);
            DollUpperArmL.SetActive(true);
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

    private IEnumerator CrawlDamage()
    {
        canTakeDamage = false;
        health -= degredationRate;
        healthBarArm1.UpdateHealth(degredationRate);
        yield return new WaitForSeconds(0.5f);
        canTakeDamage = true;
    }

}
