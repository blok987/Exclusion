using System;
using System.Runtime;

using UnityEngine;
using UnityEngine.UI;

public class UseArm : MonoBehaviour
{
    public GameObject Player;
    public GameObject armcolisionhealth;
    public Canvas c;
    public GameObject arm1;
    public GameObject arm11;
    public GameObject arm2;
    public GameObject arm22;
    public HealthArm1 h2;
    public HealthArm2 h;
    private int ran;
    public int health = 10;
    public int healthmax;
    public Image sr;
    public Sprite s;
    public Sprite vg;
    public Sprite g;
    public Sprite b;
    public Sprite vb;
    public bool prioritize0;
    public bool prioritize1;
    public bool prioritize2;
    public UseLeg ul;
    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
        armcolisionhealth = Player.transform.Find("ArmCollision&Health").gameObject;
        
        c = FindAnyObjectByType<Canvas>();
        Player = GameObject.FindWithTag("Player");
        arm1 = Player.transform.Find("Doll Forearm FRONT").gameObject;
        arm11 = Player.transform.Find("Doll Upper Arm FRONT").gameObject;
        arm2 = Player.transform.Find("Doll Forearm BACK").gameObject;
        arm22 = Player.transform.Find("Doll Upper Arm BACK").gameObject;
        ul = GetComponent<UseLeg>();    
        h2 = armcolisionhealth.GetComponent<HealthArm1>();
        h = armcolisionhealth.GetComponent<HealthArm2>();
        sr = GetComponent<Image>();
        s = sr.sprite;
        if (s == g) { health = 10; }
        if (s == b) { health = 5; }
        if (s == vb) { health = 2; }
    }
    private void Update()
    {
        if (s == null || s != g || s != b || s != vb || s != vg)
            s = sr.sprite;
           
        if (s == g) 
        { 
            health = 9; 
            healthmax = 10;
        }
        else if (s == b) 
        { 
            health = 5;
            healthmax = 10;
        }
        else if (s == vb) 
        { 
            health = 2;
            healthmax = 10;
        }
        else if (s == vg) 
        { 
            health = 15;
            healthmax = 15;
        }


    }
    public void UseA()
    {
        if (arm11.activeSelf == false & arm22.activeSelf == false)
        {
            ran = UnityEngine.Random.Range(1, 2);
            Debug.Log("random " + ran);
        }
        if (s == vg && h.health < h2.health && h.health < 15)
        {
            prioritize0 = true;
            Debug.Log("prioritize true");
        }
        if (s == vg && h.health > h2.health && h2.health < 15)
        {
            prioritize0 = false;
            Debug.Log("prioritize false");
        }
        if (s == g && h.health <h2.health && h.health < 8)
        {
            prioritize1 = true;
            Debug.Log("prioritize true");
        }
        if (s == g && h.health > h2.health && h2.health < 8)
        {
            prioritize1 = false;
            Debug.Log("prioritize false");
        }

        if (s == b && h.health < h2.health && h.health <=5 )
        {
            prioritize2 = true;
            Debug.Log("prioritize2 true");
        }
        if (s == b && h.health > h2.health && h2.health <=5 )
        {
            prioritize2 = false;
            Debug.Log("prioritize2 false");
        }
        if (arm11.activeSelf == false & arm22.activeSelf == true && h.health < 8 || ran==2 || prioritize2 ==true &&  h.health < 5 || prioritize1 == true && h.health < 8 || prioritize0 == true )
        {
            h.health = health;
            h.maxHealth = healthmax;
            arm1.SetActive(true);
            arm11.SetActive(true);
            Debug.Log("arm1");
        }   
        else if (arm22.activeSelf == false & arm11.activeSelf == true && h2.health < 8 || ran==1 || prioritize2 ==false && h2.health < 5 || prioritize1 == false && h2.health < 8|| prioritize0 == false )
        {   
            h2.health = health;
            h2.maxHealth = healthmax;
            arm2.SetActive(true);
            arm22.SetActive(true);
            Debug.Log("arm2");

        }
        
    }
}
