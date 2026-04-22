using System;
using System.Collections;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class InventoryItemInstance : MonoBehaviour
{
    public UseLeg   ul;
    public UseArm ua;
    public ItemData data;
    private inventory inventory;
    private Canvas c;
    private GameObject p;
    private Rigidbody2D prb;
    public Vector3 offset;
    public Image image;
    public Sprite s;
    public Sprite ga;
    public Sprite ba;
    public Sprite vba;
    public Sprite gl;
    public Sprite bl;
    public Sprite vbl;

    public void Start()
    {
        c = FindAnyObjectByType<Canvas>();
        inventory = c.GetComponent<inventory>();
        p = GameObject.FindWithTag("Player");
        prb = p.GetComponent<Rigidbody2D>();
         ul = GetComponent<UseLeg>();
            ua = GetComponent<UseArm>();
        image = GetComponent<Image>();
        image.sprite = data.inventorysprite;

    }

    private void FixedUpdate()

    { 
        if (image.sprite != data.inventorysprite)
            {
            image.sprite = data.inventorysprite;
        }
        if (s == null || s != ga || s != ba || s != vba || s != gl || s != bl || s != vbl)
            s = image.sprite;
        if (p == null)
        {
            p = GameObject.FindWithTag("Player");
            p = GameObject.Find("Player");
        }
        if (p.GetComponent<Rigidbody2D>() != null)
        {
            if (prb == null)
            {
                prb = p.GetComponent<Rigidbody2D>();
            }
        }
    }
    public void Use()
    {
        //data.itemBehavior.Invoke();
        if (s == ga || s == ba || s == vba){ 
            ua.UseA();
        }
        if  (s == gl || s == bl || s == vbl)    
            ul.UseL();
        inventory.items.Remove(data);
        inventory.AddItem();
        FindFirstObjectByType<inventory>().EvaluateInventory();
    }
    public void Drop()
    {
        GameObject droppedItem = Instantiate(data.ip, prb.transform.position+offset, Quaternion.identity);
        Rigidbody rb = droppedItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(prb.transform.forward * 5f, ForceMode.Impulse);
        }
        inventory.items.Remove(data);
        inventory.AddItem();
        FindFirstObjectByType<inventory>().EvaluateInventory();
   
       
    }

    

    public void sell()
    {
        inventory.items.Remove(data);
        inventory.AddItem();
        FindFirstObjectByType<inventory>().EvaluateInventory();
        //FindFirstObjectByType<shop>().SellItem(data);
    }
   
}
