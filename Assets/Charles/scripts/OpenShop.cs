using Unity.VisualScripting;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject player;
    public inventoryiteminstance iii;
    public GameObject limbToBuy;
    public int sellPrice;
    public ItemData itemData;
    public inventory i;
    public int buyPrice;

    public int greatarms;
    public int greatlegs;
    public int goodarms;
    public int goodlegs;
    public int badarms;
    public int badlegs;
    public int varrybadarms;
    public int varrybadlegs;
    
    public GameObject greatarm;
    public GameObject goodarm;
    public GameObject badarm;
    public GameObject varrybadarm;
    public GameObject greatleg;
    public GameObject goodleg;
    public GameObject badleg;
    public GameObject varryleg;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopUI = GameObject.Find("shop ui");
        player = GameObject.FindWithTag("Player");
        limbToBuy = GameObject.Find("buyablelimbs");
        shopUI.SetActive(false);
        greatarms= Random.Range(0, 2);
        greatlegs = Random.Range(0, 2);
        goodarms = Random.Range(0, 4);
        goodlegs = Random.Range(0, 4);
        badarms = Random.Range(0, 6);
        badlegs = Random.Range(0, 6);
        varrybadarms = Random.Range(0, 8);
        varrybadlegs = Random.Range(0, 8);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Openshop() 
    {
        shopUI.SetActive(true);
        
    }
    public void Closeshop()
    { 
        shopUI.SetActive(false);
    }
    public void Buy()
    {

         if (greatarms > 0)
         {
             buyPrice = 10;
         }
         if (greatlegs > 0)
         {
            buyPrice = 10;
         }
         if (goodarms > 0)
         {
             buyPrice = 7;
         }
         if (badarms > 0)
         {
             buyPrice = 5;
         }
         if (varrybadarms > 0)
         {
             buyPrice = 3;
        }
        inventory.items.Add(itemData);
        i.AddItem();

        

    }
    public void sell()
    {
        if (buyPrice > 0)
        {

        }
        else
        {
            Debug.Log("You don't have any items to sell!");
        }
    }
    public void UpdateShopUI()
    {

    }
     
}

public class inventoryiteminstance
{
}