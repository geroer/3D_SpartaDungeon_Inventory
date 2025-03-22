using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private List<ItemData> items;

    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private Button backButton;

    private List<UISlot> slots = new List<UISlot>();

    void Start()
    {
        backButton.onClick.AddListener(CloseInventory);
    }

    public void CloseInventory()
    {
        UIManager.Instance.ShowUI(UIManager.Instance.GetUIInventory().gameObject, false);
        UIManager.Instance.GetMainMenu().ShowButtons();
    }

    public void OpenInventoryUI()
    {
        items = GameManager.Instance.GetPlayer().inventory;

        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        SetSlot();
    }

    public void SetSlot()
    {
        foreach (ItemData item in items)
        {
            UISlot newSlot = Instantiate(slotPrefab, slotParent);
            newSlot.SetItem(item);
            slots.Add(newSlot);
        }
    }

    public void RefreshSlotUI()
    {
        foreach(UISlot slot in slots)
        {
            slot.RefreshUI();
        }
    }
}
