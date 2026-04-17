using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class UseLeg : MonoBehaviour
{
    public GameObject Player;
    public GameObject legcolisionhealth;
    public Canvas c;
    public GameObject leg1;
    public GameObject leg11;
    public GameObject leg2;
    public GameObject leg22;
    public GameObject cleg1;
    public Image cleg11;
    public GameObject cleg2;
    public Image cleg22;
    public HealthLeg1 h;
    public HealthLeg2 h2;
    public ItemData id;



    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
        legcolisionhealth = Player.transform.Find("LegCollision&Health").gameObject;
        
        c = FindAnyObjectByType<Canvas>();
        Player = GameObject.FindWithTag("Player");
        leg1 = Player.transform.Find("Doll Leg FRONT").gameObject;
        leg11 = Player.transform.Find("Doll Thigh FRONT").gameObject;
        leg2 = Player.transform.Find("Doll Leg BACK").gameObject;
        leg22 = Player.transform.Find("Doll Thigh BACK").gameObject;
        cleg1 = c.transform.Find("stuffbackground/playerlimbs/gameobject/L leg").gameObject;
        if (cleg1 != null)
        {
            cleg11 = cleg1.transform.GetComponent<Image>();
        }
        cleg2 = c.transform.Find("stuffbackground/playerlimbs/gameobject/R leg").gameObject;
        if (cleg2 != null)
        {
            cleg22 = cleg2.transform.GetComponent<Image>();
        }
        h = legcolisionhealth.GetComponent<HealthLeg1>();
        h2 = legcolisionhealth.GetComponent<HealthLeg2>();

    }
    void Update()
    {
        //c = FindAnyObjectByType<Canvas>();
        
        //leg1 = Player.transform.Find("Doll Leg FRONT").gameObject;
        //leg11 = Player.transform.Find("Doll Thigh FRONT").gameObject;
        //leg2 = Player.transform.Find("Doll Leg BACK").gameObject;
       // leg22 = Player.transform.Find("Doll Thigh BACK").gameObject;
        
        if (cleg1 == null)
        {
            cleg1 = c.transform.Find("stuff background/playerlimbs/limbs/L leg").gameObject;
        }
        if (cleg1 != null && cleg11 == null)
        {
            cleg11 = cleg1.transform.GetComponent<Image>();
        }
        if (cleg2 == null)
        {
            cleg2 = c.transform.Find("stuff background/playerlimbs/limbs/R leg").gameObject;
        }
        if (cleg2 != null && cleg22 == null)
        {
            cleg22 = cleg2.transform.GetComponent<Image>();
        }

    }
    public void UseL()
    {
        if (leg11.activeSelf == false)
        {
            h.health = h.maxHealth;
            leg1.SetActive(true);
            leg11.SetActive(true);
            cleg11.color = new Color(1, 1, 1, 1f);
            
        }
        else if (leg2.activeSelf == false)
        {
            h2.health = h2.maxHealth;   
            leg2.SetActive(true);
            leg22.SetActive(true);
            cleg22.color = new Color(1, 1, 1, 1f);
            
        }
    }
}
