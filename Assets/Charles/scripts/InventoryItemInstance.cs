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
 
    public void Start()
    {
        c = FindAnyObjectByType<Canvas>();
        inventory = c.GetComponent<inventory>();
        p = GameObject.FindWithTag("Player");
        prb = p.GetComponent<Rigidbody2D>();
         ul = GetComponent<UseLeg>();
            ua = GetComponent<UseArm>();
    }
    private void FixedUpdate()
    {
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
        ua.UseA();
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
