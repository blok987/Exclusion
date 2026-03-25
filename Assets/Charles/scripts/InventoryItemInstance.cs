using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class InventoryItemInstance : MonoBehaviour
{
    public ItemData data;
    private inventory inventory;
    private Canvas c;
    public void Start()
    {
        c = FindAnyObjectByType<Canvas>();
        inventory = c.GetComponent<inventory>();
    }
    public void Use()
    {
        data.itemBehavior.Invoke();
        inventory.items.Remove(data);
        inventory.AddItem();
        FindFirstObjectByType<inventory>().EvaluateInventory();
    }
}
