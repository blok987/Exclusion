using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.CoreUtils;

public class UseLeg : MonoBehaviour
{
    public GameObject Player;
    public GameObject legcolisionhealth;
    public Canvas c;
    public GameObject leg1;
    public GameObject leg11;
    public GameObject leg2;
    public GameObject leg22;
    
    public HealthLeg1 h2;
    public HealthLeg2 h;
    private int ran;
    public int health;
    public Image sr;
    public Sprite s;
    //public Sprite vg;
    public Sprite g;
    public Sprite b;
    public Sprite vb;
    public bool prioritize;
    public bool prioritize2;
    public UseArm ua;
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
        ua = GetComponent<UseArm>();
        h = legcolisionhealth.GetComponent<HealthLeg2>();
        h2 = legcolisionhealth.GetComponent<HealthLeg1>();
        sr = GetComponent<Image>();
        s = sr.sprite;

    }
    private void Update()
    {
        //|| s != vb
        if (s == null || s != g || s != b || s != vb )
            s = sr.sprite;

        if (s == g)
        {
            health = 10;

        }
        else if (s == b)
        {
            health = 5;
           
        }
        else if (s == vb)
        {
            health = 2;
           
        }
        //else  if (s == vb)
        //{
         //   health = 0;

        //}

    }

    public void UseL()
    {
        if (leg11.activeSelf == false & leg22.activeSelf == false)
        {
            ran = UnityEngine.Random.Range(1, 2);
            Debug.Log("random2 " + ran);
        }
        //if (s == vg && h.health < h2.health && h.health < 11)
        //{
        //    prioritize = true;
        //    Debug.Log("prioritize true");
        //}
        //if (s == vg && h.health > h2.health && h2.health <11)
        //{
        //    prioritize = false;
        //    Debug.Log("prioritize false");
        //}
        if (s == g && h.health < h2.health && h.health < 8)
        {
            prioritize = true;
            Debug.Log("prioritize true");
        }
        if (s == g && h.health > h2.health && h2.health < 8)
        {
            prioritize = false;
            Debug.Log("prioritize false");
        }

        if (s == b && h.health < h2.health && h.health <= 5)
        {
            prioritize2 = true;
            Debug.Log("prioritize2 true");
        }
        if (s == b && h.health > h2.health && h2.health <= 5)
        {
            prioritize2 = false;
            Debug.Log("prioritize2 false");
        }
        if (leg11.activeSelf == false & leg22.activeSelf == true && h.health < 8 || ran == 2 || prioritize2 == true && h.health < 5 || prioritize == true)
        {
            h.health = health;
            leg1.SetActive(true);
            leg11.SetActive(true);
            Debug.Log("leg1");
        }


        if (leg22.activeSelf == false & leg11.activeSelf == true && h2.health < 8 || ran == 1 || prioritize2 == false && h2.health < 5 || prioritize == false)
        {
            h2.health = health;
            leg2.SetActive(true);
            leg22.SetActive(true);
            Debug.Log("leg2");

        }

    }
}
