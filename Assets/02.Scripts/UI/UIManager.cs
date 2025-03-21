using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uIInventory;

    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public UIMainMenu GetMainMenu()
    {
        return uiMainMenu;
    }

    public UIStatus GetUIStatus()
    {
        return uiStatus;
    }

    public UIInventory GetUIInventory()
    {
        return uIInventory;
    }

    public void ShowUI(GameObject ui, bool isActive)
    {
        if (ui != null)
            ui.SetActive(isActive);
    }
}
