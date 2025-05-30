﻿using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private Image equippedIcon;
    [SerializeField] private Button slotButton;

    private ItemData itemData;

    private void Start()
    {
        slotButton.onClick.AddListener(OpenItemInfoUI);
    }

    public void SetItem(ItemData item)
    {
        itemData = item;
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (itemData != null)
        {
            itemIcon.sprite = itemData.icon;
            itemIcon.gameObject.SetActive(true);
            equippedIcon.gameObject.SetActive(IsEquipped());
        }
        else
        {
            itemIcon.gameObject.SetActive(false);
            equippedIcon.gameObject.SetActive(false);
        }
    }

    public bool IsEquipped()
    {
        if (itemData.itemType == ItemType.Weapon)
        {
            if (itemData == GameManager.Instance.GetPlayer().weapon)
                return true;
            else
                return false;
        }
        else if (itemData.itemType == ItemType.Armor)
        {
            if (itemData == GameManager.Instance.GetPlayer().armor)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    void OpenItemInfoUI()
    {
        UIManager.Instance.GetUIItemInfo().gameObject.SetActive(true);
        UIManager.Instance.GetUIItemInfo().SetItemInfo(itemData, IsEquipped());
    }
}
