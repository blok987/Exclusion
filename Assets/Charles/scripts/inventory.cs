using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class inventory : MonoBehaviour
{
    public static List<ItemData> items = new();
    public GameObject Inventory;

    private inventoryslot[] slots;
    public void Awake()
    {
        slots = GetComponentsInChildren<inventoryslot>(true);

    }
    public void Update()
    {
        EvaluateInventory();
    }

    public void EvaluateInventory() 
    { 
        for (int i = 0; i < slots.Length; ++i)
        {
            slots[i].SetItem(i <= items.Count ? items[i] : null);
        }
    }








}
//22:12 video 