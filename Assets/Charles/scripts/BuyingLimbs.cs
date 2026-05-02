using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class BuyingLimbs : MonoBehaviour
{
    public GameObject shopiu;
    public OpenShop os;
    public ItemData itemData;
    public inventory i;

    public int greatarms;
    public int greatlegs;
    public int goodarms;
    public int goodlegs;
    public int badarms;
    public int badlegs;
    public int verybadarms;
  
    public int buyPrice;

    public Sprite vga;
    public Sprite vgl;
    public Sprite ga;
    public Sprite gl;
    public Sprite ba;
    public Sprite bl;
    public Sprite vba;

    public UnityEngine.UI.Image sr;
    public Sprite cs;

    public Canvas canvas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopiu = GameObject.Find("shop iu");

        os = shopiu.GetComponent<OpenShop>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        i = canvas.GetComponent<inventory>();
        sr = GetComponent<UnityEngine.UI.Image>();
        cs = sr.sprite;
        greatarms = os.greatarms;
        goodarms = os.goodarms;
        badarms = os.badarms;
        verybadarms = os.verybadarms;
        greatlegs = os.greatlegs;
        goodlegs = os.goodlegs;
        badlegs = os.badlegs;
        if (greatlegs == 0 && cs == vgl)
        {
            this.gameObject.SetActive(false);
        }
        if (greatarms == 0 && cs == vga)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Buy()
    {
        if (cs == vga || cs == vgl)
        {
            buyPrice = 15;
            if (cs == vga)
            {
                greatarms -= 1;
            }
            else if (cs == vgl)
            {
                greatlegs -=1;
            }
        }
        else if (cs == ga || cs == gl)
        {
            buyPrice = 10;
            if (cs == ga)
            {
                goodarms -= 1;
            }
            else if (cs == gl)
            {
                goodlegs -= 1;
            }
        }
        else if (cs == ba || cs == bl)
        {
            buyPrice = 7;
            if (cs == ba)
            {
                badarms -= 1;
            }
            else if (cs == bl)
            {
                badlegs -= 1;
            }
        }
        else if (cs == vba)
        {
            buyPrice = 3;
            verybadarms -= 1;
            
        }

        inventory.items.Add(itemData);
        i.AddItem();
    }

}
