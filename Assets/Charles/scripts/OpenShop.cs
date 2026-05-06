using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject player;
    public InventoryItemInstance iii;
   
    public int buyPrice;

    public int greatarms;
    public int greatlegs;
    public int goodarms;
    public int goodlegs;
    public int badarms;
    public int badlegs;
    public int verybadarms;
   
    
    public GameObject greatarm;
    public GameObject goodarm;
    public GameObject badarm;
    public GameObject verybadarm;
    public GameObject greatleg;
    public GameObject goodleg;
    public GameObject badleg;

    public bool isopen;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        shopUI = this.gameObject;
        player = GameObject.FindWithTag("Player");
       
        shopUI.SetActive(false);
        greatarms= Random.Range(0, 2);
        greatlegs = Random.Range(0, 2);
        goodarms = Random.Range(1, 4);
        goodlegs = Random.Range(1, 4);
        badarms = Random.Range(1, 6);
        badlegs = Random.Range(1, 6);
        verybadarms = Random.Range(1, 8);
       

    }

    // Update is called once per frame
    
    public void Openshop() 
    {
        shopUI.SetActive(true);
        isopen = true;
        
    }
    public void Closeshop()
    { 
        shopUI.SetActive(false);
        isopen = false;

    }
   
        
    
    public void UpdateShopUI()
    {

    }
     
}