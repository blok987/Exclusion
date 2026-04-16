using System;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class UseArm : MonoBehaviour
{
    private GameObject Player;
    private GameObject armcolisionhealth;
    private Canvas c;
    private GameObject arm1;
    private GameObject arm11;
    private GameObject arm2;
    private GameObject arm22;
    public Image carm1;
    public Image carm2;
    public GameObject stuffbackground;
    public GameObject playerlimbs;
    public GameObject gameobject;
    private ItemData itemData;
    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
        itemData = GetComponent<ItemData>();
        c = FindAnyObjectByType<Canvas>();
        stuffbackground = c.transform.Find("Stuff Background").gameObject;
        playerlimbs = stuffbackground.transform.Find("Player Limbs").gameObject;
        gameobject = playerlimbs.transform.Find("GameObject").gameObject;
        Player = GameObject.FindWithTag("Player");
        arm1 = Player.transform.Find("Doll Upper Arm FRONT").gameObject;
        arm11 = Player.transform.Find("Doll Forearm FRONT").gameObject;
        arm2 = Player.transform.Find("Doll Upper Arm BACK").gameObject;
        arm22 = Player.transform.Find("Doll Forearm BACK").gameObject;
        carm1 = gameobject.transform.Find("L leg").GetComponent<Image>();
        carm2 = gameobject.transform.Find("R leg").GetComponent<Image>();
    }
    void Update()
    {
        if (Player == null)
        {
            itemData = GetComponent<ItemData>();
            c = FindAnyObjectByType<Canvas>();
            stuffbackground = c.transform.Find("Stuff Background").gameObject;
            playerlimbs = stuffbackground.transform.Find("Player Limbs").gameObject;
            gameobject = playerlimbs.transform.Find("GameObject").gameObject;
            Player = GameObject.FindWithTag("Player");
            arm1 = Player.transform.Find("Doll Upper Arm FRONT").gameObject;
            arm11 = Player.transform.Find("Doll Forearm FRONT").gameObject;
            arm2 = Player.transform.Find("Doll Upper Arm BACK").gameObject;
            arm22 = Player.transform.Find("Doll Forearm BACK").gameObject;
            carm1 = gameobject.transform.Find("L leg").GetComponent<Image>();
            carm2 = gameobject.transform.Find("R leg").GetComponent<Image>();
        }
        
    }
    public void UseA()
    {
        if (arm1.activeSelf == false)
        {
            arm1.SetActive(true);
            arm11.SetActive(true);
            carm1.color = new Color(1, 1, 1, 1f);
        }
        else
        {
            arm1.SetActive(false);
            arm11.SetActive(false);
            carm1.color = new Color(1, 1, 1, 0.5f);
        }
    }
}
