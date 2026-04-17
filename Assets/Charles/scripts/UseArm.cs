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
    public GameObject carm1;
    public Image carm11;
    public GameObject carm2;
    public Image carm22;
    public HealthArm1 h;
    public HealthArm2 h2;
    public ItemData id;
    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
        armcolisionhealth = Player.transform.Find("ArmCollision&Health").gameObject;
        id = GetComponent<ItemData>();
        c = FindAnyObjectByType<Canvas>();
        Player = GameObject.FindWithTag("Player");
        arm1 = Player.transform.Find("Doll Forearm FRONT").gameObject;
        arm11 = Player.transform.Find("Doll Upper Arm FRONT").gameObject;
        arm2 = Player.transform.Find("Doll Forearm BACK").gameObject;
        arm22 = Player.transform.Find("Doll Upper Arm BACK").gameObject;
        carm1 = c.transform.Find("stuffbackground/playerlimbs/gameobject/L arm").gameObject;
        if (carm1 != null)
        {
            carm11 = carm1.transform.GetComponent<Image>();
        }
        carm2 = c.transform.Find("stuffbackground/playerlimbs/gameobject/R arm").gameObject;
        if (carm2 != null)
        {
            carm22 = carm2.transform.GetComponent<Image>();
        }
    }
    void Update()
    {
        c = FindAnyObjectByType<Canvas>();

        arm1 = Player.transform.Find("Doll Forearm FRONT").gameObject;
        arm11 = Player.transform.Find("Doll Upper Arm FRONT").gameObject;
        arm2 = Player.transform.Find("Doll Forearm BACK").gameObject;
        arm22 = Player.transform.Find("Doll Upper Arm BACK").gameObject;
        // Fix: Find the child transform, then get the Image component from it
        if (carm1 == null)
        {
             carm1 = c.transform.Find("stuff background/playerlimbs/limbs/L leg").gameObject;
        }
         if (carm1 != null && carm11 == null)
        {
            carm11 = carm1.transform.GetComponent<Image>();
        }
        if (carm2 == null)
        {
            carm2 = c.transform.Find("stuff background/playerlimbs/limbs/R leg").gameObject;
        }
        if (carm2 != null && carm22 == null)
        {
             carm22 = carm2.transform.GetComponent<Image>();
        }
       
    }
    public void UseA()
    {
        if (arm1.activeSelf == false)
        {
            arm1.SetActive(true);
            arm11.SetActive(true);
            carm11.color = new Color(1, 1, 1, 1f);
        }
        else
        {
            arm1.SetActive(false);
            arm11.SetActive(false);
            carm11.color = new Color(1, 1, 1, 1f);
        }
        if (arm2.activeSelf == false)
        {
            arm2.SetActive(true);
            arm22.SetActive(true);
            carm22.color = new Color(1, 1, 1, 1f);
        }
        else
        {
            arm2.SetActive(false);
            arm22.SetActive(false);
            carm22.color = new Color(1, 1, 1, 1f);
        }
    }
}
