using UnityEngine;

public class inventoryslot : MonoBehaviour
{
    public void SetItem(ItemData item)
    {
        transform.GetChild(0).GetComponent<InventoryItemInstance>().data = item;
        transform.GetChild(0).gameObject.SetActive(true);
      //  transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = item.sprite();
       //1.17.33
   }
}
