using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button BackButton;

    void Start()
    {
        BackButton.onClick.AddListener(CloseInventory);
    }

    public void CloseInventory()
    {
        UIManager.Instance.ShowUI(UIManager.Instance.GetUIInventory().gameObject, false);
        UIManager.Instance.GetMainMenu().ShowButtons();
    }
}
