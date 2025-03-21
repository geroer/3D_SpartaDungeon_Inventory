using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private Image expBar;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button openStatusButton;
    [SerializeField] private Button openInventoryButton;
    [SerializeField] private TextMeshProUGUI goldText;

    void Start()
    {
        goldText.text = $"{GameManager.Instance.GetGold()}";

        openStatusButton.onClick.AddListener(OpenStatus);
        openInventoryButton.onClick.AddListener(OpenInventory);
    }

    public void SetCharacterData(Character player)
    {
        nameText.text = $"{player.Name}";
        levelText.text = $"{player.Level}";
        expText.text = $"{player.Exp} / {player.MaxExp}";
        expBar.fillAmount = player.Exp / player.MaxExp;
        descriptionText.text = $"{player.Description}";
    }

    public void OpenMainMenu()
    {
        UIManager.Instance.ShowUI(gameObject, true);
    }

    public void OpenStatus()
    {
        UIManager.Instance.GetUIStatus().SetCharacterStatus(GameManager.Instance.GetPlayer());
        UIManager.Instance.ShowUI(UIManager.Instance.GetUIStatus().gameObject, true);
        HideButtons();
    }

    public void OpenInventory()
    {
        UIManager.Instance.ShowUI(UIManager.Instance.GetUIInventory().gameObject, true);
        HideButtons();
    }

    public void ShowButtons()
    {
        openStatusButton.gameObject.SetActive(true);
        openInventoryButton.gameObject.SetActive(true);
    }

    public void HideButtons()
    {
        openStatusButton.gameObject.SetActive(false);
        openInventoryButton.gameObject.SetActive(false);
    }
}
