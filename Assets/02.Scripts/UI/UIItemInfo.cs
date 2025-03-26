using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemStatsText;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unEquipButton;
    [SerializeField] private Button closeButton;

    private ItemData itemData;
    private bool isEquipped;

    private void Start()
    {
        equipButton.onClick.AddListener(EquipItem);
        unEquipButton.onClick.AddListener(UnEquipItem);
        closeButton.onClick.AddListener(CloseUI);
    }

    public void SetItemInfo(ItemData item, bool isequipped)
    {
        itemData = item;
        isEquipped = isequipped;

        itemNameText.text = itemData.itemName;

        switch (itemData.itemType)
        {
            case ItemType.Weapon:
                WeaponData weaponData = itemData as WeaponData;
                itemStatsText.text = (weaponData.attack > 0 ? $"공격력 : {weaponData.attack}\n" : "") + (weaponData.criticalHit > 0 ? $"치명타 : {weaponData.criticalHit}" : "");
                break;
            case ItemType.Armor:
                ArmorData armorData = itemData as ArmorData;
                itemStatsText.text = (armorData.defense > 0 ? $"방어력 : {armorData.defense}\n" : "") + (armorData.helath > 0 ? $"체력 : {armorData.helath}" : "");
                break;
        }

        equipButton.gameObject.SetActive(!isEquipped);
        unEquipButton.gameObject.SetActive(isEquipped);
    }

    void EquipItem()
    {
        if (itemData != null)
        {
            GameManager.Instance.GetPlayer().Equip(itemData);
            UIManager.Instance.GetUIInventory().RefreshSlotUI();
            ButtonSet();
        }
    }

    void UnEquipItem()
    {
        if (itemData != null)
        {
            GameManager.Instance.GetPlayer().UnEquip(itemData);
            UIManager.Instance.GetUIInventory().RefreshSlotUI();
            ButtonSet();
        }
    }

    void ButtonSet()
    {
        equipButton.gameObject.SetActive(!equipButton.gameObject.activeSelf);
        unEquipButton.gameObject.SetActive(!unEquipButton.gameObject.activeSelf);
    }

    void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
