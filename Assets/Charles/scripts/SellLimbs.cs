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

    }
    public void sell() 
    { 
    
    }
    public void UpdateShopUI()
    {

    }
     
}
