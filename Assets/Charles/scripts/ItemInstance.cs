using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class ItemInstance : MonoBehaviour
{
    public ItemData itemData;
    private SpriteRenderer sr;
    private inventory i;
    private Canvas c;
    private GameObject p;
    private InventoryItemInstance III;
    public void Start()
    {
        //III= FindAnyObjectByType(type: typeof(InventoryItemInstance));    
        p = GameObject.FindWithTag("Player");
        c = FindAnyObjectByType<Canvas>();
        i = FindFirstObjectByType<inventory>();
    }
    private void Awake()
    {

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = itemData.itemSprite;
        GetComponent<BoxCollider2D>().isTrigger = false;
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
        if (other.gameObject.CompareTag("Player") & III.isdroped == false )
        {
            inventory.items.Add(itemData);
            i.AddItem();
            Destroy(gameObject);
        }
    }
}

