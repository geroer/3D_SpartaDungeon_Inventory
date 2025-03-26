using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    Misc,
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public ItemType itemType;
    public Sprite icon;
}