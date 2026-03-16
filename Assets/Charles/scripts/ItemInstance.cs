using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class ItemInstance : MonoBehaviour
{
    public ItemData itemData;
    private SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>(); 
          sr.sprite =itemData.itemSprite;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        inventory.items.Add(itemData);
        Destroy(gameObject);
       
    }
}

