using NUnit.Framework.Interfaces;
using UnityEngine;

public class BuyingLimbs : MonoBehaviour
{
    OpenShop os;
    public ItemData itemData;
    public inventory i;

    public int greatarms;
    public int greatlegs;
    public int goodarms;
    public int goodlegs;
    public int badarms;
    public int badlegs;
    public int verybadarms;
    public int verybadlegs;
    public int buyPrice;

    public Sprite vga;
    public Sprite vgl;
    public Sprite ga;
    public Sprite gl;
    public Sprite ba;
    public Sprite bl;
    public Sprite vba;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        greatarms = os.greatarms;
        goodarms = os.goodarms;
        badarms = os.badarms;
        verybadarms = os.verybadarms;
        greatlegs = os.greatlegs;
        goodlegs = os.goodlegs;
        badlegs = os.badlegs;
        
    }
    
    
    public void Buy()
    {
        if (this == vga || this == vgl)
        {
            buyPrice = 15;
            if (this == vga)
            {
                greatarms -= 1;
            }
            else if (this == vgl)
            {
                greatlegs -=1;
            }
        }
        else if (this == ga || this == gl)
        {
            buyPrice = 10;
            if (this == ga)
            {
                goodarms -= 1;
            }
            else if (this == gl)
            {
                goodlegs -= 1;
            }
        }
        else if (this == ba || this == bl)
        {
            buyPrice = 7;
            if (this == ba)
            {
                badarms -= 1;
            }
            else if (this == bl)
            {
                badlegs -= 1;
            }
        }
        else if (this == vba)
        {
            buyPrice = 3;
            verybadarms -= 1;
            
        }

        inventory.items.Add(itemData);
        i.AddItem();
    }

}
