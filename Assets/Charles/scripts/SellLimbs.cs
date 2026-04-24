using Unity.VisualScripting;
using UnityEngine;

public class SellLimbs : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject player;
    public GameObject limbToSell;
    public GameObject limbToBuy;
    public int sellPrice;
    public ItemData itemData;
    public inventory i;
    public inventory inventory;
    public int buyPrice;

    public int greatitems;
    public int gooditems;
    public int baditems;
    public int badbuyitems;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopUI = GameObject.Find("shop ui");
        player = GameObject.FindWithTag("Player");
        shopUI.SetActive(false);
        greatitems = Random.Range(0, 3);
        gooditems = Random.Range(0, 4);
        baditems = Random.Range(0, 6);
        badbuyitems = Random.Range(0, 7);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenShop() 
    {
        shopUI.SetActive(true);
    }
    public void CloseShop()
    { 
        shopUI.SetActive(false);
    }
    public void Buy()
    {
         if (greatitems > 0)
         {
             buyPrice = 10;
         }
         else if (gooditems > 0)
         {
             buyPrice = 7;
         }
         else if (baditems > 0)
         {
             buyPrice = 5;
         }
         else if (badbuyitems > 0)
         {
             buyPrice = 3;
        }
        inventory.items.Add(itemData);
        i.AddItem();

        greatitems -= 1;

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
