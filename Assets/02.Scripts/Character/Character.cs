using System.Collections.Generic;

public class Character
{
    //기본 정보
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Exp { get; private set; }
    public int MaxExp { get; private set; }
    public string Description { get; private set; }

    //캐릭터 스펙
    public int BaseAttack { get; private set; }
    public int BaseDefense { get; private set; }
    public int BaseHealth { get; private set; }
    public int BaseCriticalHit { get; private set; }

    //장비 스펙
    public int equippedAttack;
    public int equippedDefense;
    public int equippedHealth;
    public int equippedCriticalHit;

    //장비 적용 스펙
    public int TotalAttack => BaseAttack + equippedAttack;
    public int TotalDefense => BaseDefense + equippedDefense;
    public int TotalHealth => BaseHealth + equippedHealth;
    public int TotalCriticalHit => BaseCriticalHit + equippedCriticalHit;

    public List<ItemData> inventory;

    public ItemData weapon;
    public ItemData armor;

    public Character(string name, int level, int exp, int maxExp, string description, int attack, int defense, int health, int criticalHit, List<ItemData> items)
    {
        Name = name;
        Level = level;
        Exp = exp;
        MaxExp = maxExp;
        Description = description;
        BaseAttack = attack;
        BaseDefense = defense;
        BaseHealth = health;
        BaseCriticalHit = criticalHit;
        inventory = items;
    }

    public void Equip(ItemData item)
    {
        if (item != null)
        {
            switch (item.itemType)
            {
                case ItemType.Weapon:
                    WeaponData weaponData = item as WeaponData;
                    weapon = item;
                    equippedAttack = weaponData.attack;
                    equippedCriticalHit = weaponData.criticalHit;
                    break;
                case ItemType.Armor:
                    ArmorData armorData = item as ArmorData;
                    armor = item;
                    equippedDefense = armorData.defense;
                    equippedHealth = armorData.helath;
                    break;
            }
        }
    }

    public void UnEquip(ItemData item)
    {
        if (item != null)
        {
            switch (item.itemType)
            {
                case ItemType.Weapon:
                    weapon = null;
                    equippedAttack = 0;
                    equippedCriticalHit = 0;
                    break;
                case ItemType.Armor:
                    armor = null;
                    equippedDefense = 0;
                    equippedHealth = 0;
                    break;
            }
        }
    }
}