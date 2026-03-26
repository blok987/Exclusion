using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.InputSystem;


public class inventory : MonoBehaviour
{
    public static List<ItemData> items = new();
    public GameObject Inventory;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;
    public GameObject s6;
    public GameObject s7;
    public GameObject s8;
    private inventoryslot[] slots;
    public Component ol1;
    public Component ol2;
    public Component ol3;
    public Component ol4;
    public Component ol5;
    public Component ol6;
    public Component ol7;
    public Component ol8;
    public string selectedslot;
    public InventoryItemInstance III;
    public GameObject sc;
    public GameObject ss;
    private GameObject player;
    private PlayerInput pi;
    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pi = player.GetComponent<PlayerInput>();
        slots = GetComponentsInChildren<inventoryslot>(true);
        if (slots.Length > 0) s1 = slots[0]?.gameObject;
        if (slots.Length > 1) s2 = slots[1]?.gameObject;
        if (slots.Length > 2) s3 = slots[2]?.gameObject;
        if (slots.Length > 3) s4 = slots[3]?.gameObject;
        if (slots.Length > 4) s5 = slots[4]?.gameObject;
        if (slots.Length > 5) s6 = slots[5]?.gameObject;
        if (slots.Length > 6) s7 = slots[6]?.gameObject;
        if (slots.Length > 7) s8 = slots[7]?.gameObject;
        ol1 = s1.GetComponent<Outline>();
        ol2 = s2.GetComponent<Outline>();
        ol3 = s3.GetComponent<Outline>();
        ol4 = s4.GetComponent<Outline>();
        ol5 = s5.GetComponent<Outline>();
        ol6 = s6.GetComponent<Outline>();
        ol7 = s7.GetComponent<Outline>();
        ol8 = s8.GetComponent<Outline>();
       
    }
    public void Start()
    {
        selectedslot = "s1";
        scroll();
        
       
    }
    public void scroll()
    {
        if (selectedslot == "s1")
        {
            ((Outline)ol1).enabled = true;
            ((Outline)ol2).enabled = false;
            ((Outline)ol3).enabled = false;
            ((Outline)ol4).enabled = false;
            ((Outline)ol5).enabled = false;
            ((Outline)ol6).enabled = false;
            ((Outline)ol7).enabled = false;
            ((Outline)ol8).enabled = false;
        }
        else if (selectedslot == ("s2"))
        {
            ((Outline)ol2).enabled = true;
            ((Outline)ol1).enabled = false;
            ((Outline)ol3).enabled = false;
            ((Outline)ol4).enabled = false;
            ((Outline)ol5).enabled = false;
            ((Outline)ol6).enabled = false;
            ((Outline)ol7).enabled = false;
            ((Outline)ol8).enabled = false;
        }
        else if (selectedslot == "s3")
        {
            ((Outline)ol1).enabled = false;
            ((Outline)ol2).enabled = false;
            ((Outline)ol3).enabled = true;
            ((Outline)ol4).enabled = false;
            ((Outline)ol5).enabled = false;
            ((Outline)ol6).enabled = false;
            ((Outline)ol7).enabled = false;
            ((Outline)ol8).enabled = false;
        }
        else if (selectedslot == "s4")
        {
            ((Outline)ol1).enabled = false;
            ((Outline)ol2).enabled = false;
            ((Outline)ol3).enabled = false;
            ((Outline)ol4).enabled = true;
            ((Outline)ol5).enabled = false;
            ((Outline)ol6).enabled = false;
            ((Outline)ol7).enabled = false;
            ((Outline)ol8).enabled = false;
        }
        else if (selectedslot == "s5")
        {
            ((Outline)ol1).enabled = false;
            ((Outline)ol2).enabled = false;
            ((Outline)ol3).enabled = false;
            ((Outline)ol4).enabled = false;
            ((Outline)ol5).enabled = true;
            ((Outline)ol6).enabled = false;
            ((Outline)ol7).enabled = false;
            ((Outline)ol8).enabled = false;
        }
        else if (selectedslot == "s6")
        {
            ((Outline)ol1).enabled = false;
            ((Outline)ol2).enabled = false;
            ((Outline)ol3).enabled = false;
            ((Outline)ol4).enabled = false;
            ((Outline)ol5).enabled = false;
            ((Outline)ol6).enabled = true;
            ((Outline)ol7).enabled = false;
            ((Outline)ol8).enabled = false;
        }
        else if (selectedslot == "s7")
        {
            ((Outline)ol1).enabled = false;
            ((Outline)ol2).enabled = false;
            ((Outline)ol3).enabled = false;
            ((Outline)ol4).enabled = false;
            ((Outline)ol5).enabled = false;
            ((Outline)ol6).enabled = false;
            ((Outline)ol7).enabled = true;
            ((Outline)ol8).enabled = false;
        }
        else if (selectedslot == "s8")
        {
            ((Outline)ol1).enabled = false;
            ((Outline)ol2).enabled = false;
            ((Outline)ol3).enabled = false;
            ((Outline)ol4).enabled = false;
            ((Outline)ol5).enabled = false;
            ((Outline)ol6).enabled = false;
            ((Outline)ol7).enabled = false;
            ((Outline)ol8).enabled = true;
        }

        
    }
    public void Update()
    {
        
        if (selectedslot == "s1")
            ss = s1;
        else if (selectedslot == "s2")
            ss = s2;
        else if (selectedslot == "s3")
            ss = s3;
        else if (selectedslot == "s4")
            ss = s4;
        else if (selectedslot == "s5")
            ss = s5;
        else if (selectedslot == "s6")
            ss = s6;
        else if (selectedslot == "s7")
            ss = s7;
        else if (selectedslot == "s8")
            ss = s8;

        if (ss != null && ss.transform.childCount > 0)
        {
            sc = ss.transform.GetChild(0).gameObject;
        }
        else
        {
            sc = null;
        }
        if (Input.mouseScrollDelta.y > 0)
        {
          
            selectedslot = selectedslot switch
            {
                "s8" => "s1",
                "s1" => "s2",
                "s2" => "s3",
                "s3" => "s4",
                "s4" => "s5",
                "s5" => "s6",
                "s6" => "s7",
                "s7" => "s8",
                _ => selectedslot
                
            };
            scroll();
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            selectedslot = selectedslot switch
            {
                "s1" => "s8",
                "s8" => "s7",
                "s7" => "s6",
                "s6" => "s5",
                "s5" => "s4",
                "s4" => "s3",
                "s3" => "s2",
                "s2" => "s1",
                _ => selectedslot
                
            };
            scroll();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (sc.GetComponent<InventoryItemInstance>().data != null)
            {
                
                sc.GetComponent<InventoryItemInstance>().Use();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (sc.GetComponent<InventoryItemInstance>().data != null)
            {
                sc.GetComponent<InventoryItemInstance>().Drop();
            }
        }


    }
    public void AddItem()
    {
       
        EvaluateInventory();
    }




    public void EvaluateInventory() 
    { 
        for (int i = 0; i < slots.Length; ++i)
        {
           
            slots[i].SetItem(i < items.Count ? items[i] : null);
        }
        
    }

}