using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Scriptable Object/Item Data")]
public class ItemData : ScriptableObject
{
   [TextArea] public string description;
    public string itenprice;
    public Sprite itemSprite;
    public Sprite inventorysprite;
    public string itemQuality;
    public GameObject ip;
    public UnityEvent itemBehavior;

    
}
