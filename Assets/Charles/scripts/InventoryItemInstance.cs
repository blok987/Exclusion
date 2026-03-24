
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class InventoryItemInstance : MonoBehaviour
{
    public ItemData data;

    private Image itemImage;

    private void OnEnable()
    {
        itemImage = GetComponent<Image>();
        //itemImage.sprite = data.itemSprite;
    }

    public void Use()
    {
        data.itemBehavior.Invoke();
        inventory.items.Remove(data);
        FindFirstObjectByType<inventory>().EvaluateInventory();
    }
}
