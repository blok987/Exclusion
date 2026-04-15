using UnityEngine;
using UnityEngine.UI;

public class LimbFade : MonoBehaviour
{
    public Health h;
    public HealthArm1 ha1;
    public HealthArm2 ha2;
    public HealthLeg1 hl1;
    public HealthLeg2 hl2;
    public GameObject player;
    public GameObject limb;
    public float currant;
    private float health;
    private Image i;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        limb = this.gameObject;
        i= this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (limb.name == "L arm")
        { 
            ha1 = player.GetComponentInChildren<HealthArm1>();
            
            health = ha1.health;
        }
        else if (limb.name == "R arm")
        {
            ha2 = player.GetComponentInChildren<HealthArm2>();
            health = ha2.health;
        }
        else if (limb.name == "L leg")
        {
            hl1 = player.GetComponentInChildren<HealthLeg1>();
            health = hl1.health;
        }
        else if (limb.name == "R leg")
        {
            hl2 = player.GetComponentInChildren<HealthLeg2>();
            health = hl2.health;
        }
        else if (limb.name == "torso+head")
        { 
            h = player.GetComponentInChildren<Health>();
            health = h.health;
        }
        
        
            
        

        fade();
    }
    public void fade()
    {
        
        
        currant = health / 10f;
        i.color = new Color(1, 1, 1, currant);
       

    }
}
