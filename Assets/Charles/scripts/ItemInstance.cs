using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(PolygonCollider2D))]
public class ItemInstance : MonoBehaviour
{
    public ItemData itemData;
    private SpriteRenderer sr;
    private inventory i;
    private Canvas c;
    private GameObject p;
   
    
    public void Start()
    {
  
       
        p = GameObject.FindWithTag("Player");
        c = FindAnyObjectByType<Canvas>();
        i = FindFirstObjectByType<inventory>();
    }
    private void Awake()
    {

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = itemData.itemSprite;
        GetComponent<PolygonCollider2D>().isTrigger = false;
    }
    private void Update()
    {
       
       
        
        if (p == null)
        {
            p = GameObject.FindWithTag("Player");
            p = GameObject.Find("Player");
        }
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            sr.sprite =  itemData.inventorysprite;
            inventory.items.Add(itemData);
            i.AddItem(); 
            sr.sprite = itemData.inventorysprite;
            Destroy(gameObject);
        }
    }
    
}

