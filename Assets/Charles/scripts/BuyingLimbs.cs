using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework.Interfaces;
using System;
using UnityEditor;
using UnityEngine;

public class BuyingLimbs : MonoBehaviour
{
    public GameObject shopiu;
    public OpenShop os;
    public ItemData itemData;
    public inventory i;
    
    public GameObject player;
    public GameObject money;
    public TMPro.TextMeshProUGUI moneytext;

    public GameObject asp;
    public GameObject ap;
    public GameObject adp;
    public GameObject afdp;

    public GameObject lsp;
    public GameObject lp;
    public GameObject ldp;
    public GameObject lfdp;

    public float greatarms;
    public float greatlegs;
    public float goodarms;
    public float goodlegs;
    public float badarms;
    public float badlegs;
    public float verybadarms;
  
    public float buyPrice;

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
        player = GameObject.FindWithTag("Player");
        os = shopiu.GetComponent<OpenShop>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //money = GameObject.Find("Canvas/stuff background/stuff/money holder/Money");
        //moneytext = money.GetComponent<TMPro.TextMeshProUGUI>();
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
           this.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        if (greatarms == 0 && cs == vga)
        {
           this.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        if (goodarms == 0 && cs == ga)
        {
            this.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        if (goodlegs == 0 && cs == gl)
        {
            this.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        if (badarms == 0 && cs == ba)
        {
            this.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        if (badlegs == 0 && cs == bl)
        {
            this.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        if (verybadarms == 0 && cs == vba)
        {
            this.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }

    }

    public void Buy()
    {
        if (cs == vga || cs == vgl)
        {
            buyPrice = 15;
            if (cs == vga)
            {
               
                if (greatarms > 0)
                {
                    Instantiate(asp, player.transform.position, Quaternion.identity);
                    greatarms -= 1;
                }
                
            }
            else if (cs == vgl)
            {
               
                if (greatlegs > 0)
                {
                    Instantiate(lsp, player.transform.position, Quaternion.identity);
                    greatlegs -=1;
                }

            }
        }
        else if (cs == ga || cs == gl)
        {
            buyPrice = 10;
            if (cs == ga)
            {
               
                if (goodarms > 0)
                {
                    Instantiate(ap, player.transform.position, Quaternion.identity);
                    goodarms -= 1;
                }

            }
            else if (cs == gl)
            {
                
                if (goodlegs > 0)
                {
                    Instantiate(lp, player.transform.position, Quaternion.identity);
                    goodlegs -= 1;
                }

            }
        }
        else if (cs == ba || cs == bl)
        {
            buyPrice = 7;
            if (cs == ba)
            {
                
                if (badarms > 0)
                {
                    Instantiate(adp, player.transform.position, Quaternion.identity);
                    badarms -= 1;
                }

            }
            else if (cs == bl)
            {
                
                if (badlegs > 0)
                {
                    Instantiate(ldp, player.transform.position, Quaternion.identity);
                    badlegs -= 1;
                }

            }
        }
        else if (cs == vba)
        {
            buyPrice = 3;
            
            if (verybadarms > 0)
            {
                Instantiate(afdp, player.transform.position, Quaternion.identity);
                verybadarms -= 1;
            }

        }

        inventory.items.Add(itemData);
        i.AddItem();
    }

}
