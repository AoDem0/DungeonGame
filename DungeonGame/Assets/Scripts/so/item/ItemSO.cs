using UnityEngine;

public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    [TextArea(3, 10)]
    public string itemDescription;
    public enum ItemType { potion, armor, weapon, trinket }
    public ItemType itemType;
}
