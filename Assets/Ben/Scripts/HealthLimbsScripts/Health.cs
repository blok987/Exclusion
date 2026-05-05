using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    private float damageForDeath;
    private bool canPassiveHeal = true;
    private bool canPassiveHealSLV = true;

    public GameObject DollHead;
    public GameObject DollChest;
    public GameObject DollMidsection;
    public GameObject DollWaist;

    public HealthBarBodyTest healthBar;
    
    public HealthArm1 healthArm1;
    public HealthArm2 healthArm2;
    public HealthLeg1 healthLeg1;
    public HealthLeg2 healthLeg2;

    public Sprite DollHeadS;
    public Sprite DollChestS;
    public Sprite DollMidsectionS;
    public Sprite DollWaistS;

    public Sprite DollHeadBD;
    public Sprite DollChestBD;
    public Sprite DollMidsectionBD;
    public Sprite DollWaistBD;

    public Sprite DollHeadFD;
    public Sprite DollChestFD;
    public Sprite DollMidsectionFD;
    public Sprite DollWaistFD;

    public Sprite DollHeadSLV;
    public Sprite DollChestSLV;
    public Sprite DollMidsectionSLV;
    public Sprite DollWaistSLV;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DollHeadS = Resources.Load<Sprite>("Limbs/NLimbs/Doll Head");
        DollChestS = Resources.Load<Sprite>("Limbs/NLimbs/Doll Chest");
        DollMidsectionS = Resources.Load<Sprite>("Limbs/NLimbs/Doll Midsection");
        DollWaistS = Resources.Load<Sprite>("Limbs/NLimbs/Doll Waist");

        DollHeadBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Head DAMAGED");
        DollChestBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Chest DAMAGED");
        DollMidsectionBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Midsection DAMAGED");
        DollWaistBD = Resources.Load<Sprite>("Limbs/BDLimbs/Doll Waist DAMAGED");

        DollHeadFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Head FULLY DAMAGED");
        DollChestFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Chest FULLY DAMAGED");
        DollMidsectionFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Midsection FULLY DAMAGED");
        DollWaistFD = Resources.Load<Sprite>("Limbs/FDLimbs/Doll Waist FULLY DAMAGED");

        DollHeadSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Head SLV");
        DollChestSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Chest SLV");
        DollMidsectionSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Midsection SLV");
        DollWaistSLV = Resources.Load<Sprite>("Limbs/SLVLimbs/Doll Waist SLV");

        maxHealth = 10;
        health = maxHealth;

        healthArm1 = transform.Find("ArmCollision&Health").GetComponent<HealthArm1>();
        healthArm2 = transform.Find("ArmCollision&Health").GetComponent<HealthArm2>();
        healthLeg1 = transform.Find("LegCollision&Health").GetComponent<HealthLeg1>();
        healthLeg2 = transform.Find("LegCollision&Health").GetComponent<HealthLeg2>();

    }

    // Update is called once per frame
    void Update()
    {
        if (health > 10)
        {
            DollHead.GetComponent<SpriteRenderer>().sprite = DollHeadSLV;
            DollChest.GetComponent<SpriteRenderer>().sprite = DollChestSLV;
            DollMidsection.GetComponent<SpriteRenderer>().sprite = DollMidsectionSLV;
            DollWaist.GetComponent<SpriteRenderer>().sprite = DollWaistSLV;
        }

        if (health > 5 && health <= 10)
        {
            DollHead.GetComponent<SpriteRenderer>().sprite = DollHeadS;
            DollChest.GetComponent<SpriteRenderer>().sprite = DollChestS;
            DollMidsection.GetComponent<SpriteRenderer>().sprite = DollMidsectionS;
            DollWaist.GetComponent<SpriteRenderer>().sprite = DollWaistS;
        }
        if (health <= 5 && health > 2)
        {
            DollHead.GetComponent<SpriteRenderer>().sprite = DollHeadBD;
            DollChest.GetComponent<SpriteRenderer>().sprite = DollChestBD;
            DollMidsection.GetComponent<SpriteRenderer>().sprite = DollMidsectionBD;
            DollWaist.GetComponent<SpriteRenderer>().sprite = DollWaistBD;
        }
        if (health <= 2)
        {
            DollHead.GetComponent<SpriteRenderer>().sprite = DollHeadFD;
            DollChest.GetComponent<SpriteRenderer>().sprite = DollChestFD;
            DollMidsection.GetComponent<SpriteRenderer>().sprite = DollMidsectionFD;
            DollWaist.GetComponent<SpriteRenderer>().sprite = DollWaistFD;
        }

        if (gameObject.transform.childCount <= 0)
        {
            damageForDeath = health;
            health -= damageForDeath;
            healthBar.UpdateHealth(damageForDeath);
        }

        if (health <= 0)
        {
            
            StartCoroutine(Wait());
            
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (healthArm1.health > 5 & healthArm1.health <= 10 && healthArm2.health > 5 & healthArm2.health <= 10 & healthLeg1.health > 5 & healthLeg1.health <= 10 & healthLeg2.health > 5 & healthLeg2.health <= 10 && canPassiveHeal)
        {
            StartCoroutine(Heal());

        }

        if (healthArm1.health > 10 && healthArm2.health > 10 & healthLeg1.health > 10 & healthLeg2.health > 10 && canPassiveHealSLV)
        {
            maxHealth = 15;
            StartCoroutine(HealSLV());
                       
        }
        else if ( healthArm1.health <= 10 && healthArm2.health <= 10 && healthLeg1.health <= 10 && healthLeg2.health <= 10 & health <= 10)
        {
            maxHealth = 10;
        }
        else if (healthArm1.health <= 10 && health <= 10 || healthArm2.health <= 10 && health <= 10 || healthLeg1.health <= 10 && health <= 10 || healthLeg2.health <= 10 & health <= 10)
        {
            maxHealth = 10;
        }

    }

    public void TakeDamage(float amount)
    {

        health -= amount;
        healthBar.UpdateHealth(amount);
        
    }


    private IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }


    private IEnumerator Heal()
    {
        canPassiveHeal = false;
        health += 0.35f;
        healthBar.UpdateHealthHeal(0.45f);
        yield return new WaitForSeconds(1);
        Debug.Log("Healing");
        canPassiveHeal = true;

    }

private IEnumerator HealSLV()
    {
        canPassiveHealSLV = false;
        health += 0.35f;
        healthBar.UpdateHealthHeal(0.35f);
        yield return new WaitForSeconds(1);
        Debug.Log("Healing");
        canPassiveHealSLV = true;

    }
}


