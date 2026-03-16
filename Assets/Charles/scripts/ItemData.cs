using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Scriptable Object/Item Data")]
public class ItemData : ScriptableObject
{
   [TextArea] public string description;
    public string itenprice;
    public Sprite itemSprite;
    public string itemQuality;
}
