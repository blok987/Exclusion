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
    public HealthArm2 h1;
    private int ran;
    public int health = 10;
    public Image sr;
    public Sprite s;
    public Sprite g;
    public Sprite b;
    public Sprite vb;
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
        
        h2 = armcolisionhealth.GetComponent<HealthArm1>();
        h1 = armcolisionhealth.GetComponent<HealthArm2>();
        sr = GetComponent<Image>();
        s = sr.sprite;
        if (s == g) { health = 10; }
        if (s == b) { health = 5; }
        if (s == vb) { health = 2; }
    }
    private void Update()
    {
        if (s == g) { health = 10; }
        if (s == b) { health = 5; }
        if (s == vb) { health = 2; }
    }
    public void UseA()
    {
        if (arm11.activeSelf == false & arm22.activeSelf == false)
        {
            ran = UnityEngine.Random.Range(1, 2);
        }
        if (arm11.activeSelf == false & arm22.activeSelf == true || ran==2)
        {
            h1.health = health; 
            arm1.SetActive(true);
            arm11.SetActive(true);
            
            Debug.Log("Arm1 activated");
        }
       
        if (arm22.activeSelf == false & arm11.activeSelf == true || ran==1)
        {   
            h2.health = health;   
            arm2.SetActive(true);
            arm22.SetActive(true);
            
            Debug.Log("Arm2 activated");
        }
        
    }
}
