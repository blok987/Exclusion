using UnityEngine;
using UnityEngine.UI;

public class inventoryslot : MonoBehaviour
{
    public void SetItem(ItemData item)
    {
        transform.GetChild(0).GetComponent<InventoryItemInstance>().data = item;
        transform.GetChild(0).GetComponent<Image>().sprite = item ? item.itemSprite : null;
        transform.GetChild(0).gameObject.SetActive(true);
        
       //1.17.33
   }

    
}
