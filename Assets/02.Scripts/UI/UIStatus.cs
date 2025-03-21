using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalHitText;
    [SerializeField] private Button BackButton;

    void Start()
    {
        BackButton.onClick.AddListener(CloseStatus);
    }

    public void SetCharacterStatus(Character player)
    {
        attackText.text = $"{player.Attack}";
        defenseText.text = $"{player.Defense}";
        healthText.text = $"{player.Health}";
        criticalHitText.text = $"{player.CriticalHit}";
    }

    public void CloseStatus()
    {
        UIManager.Instance.ShowUI(UIManager.Instance.GetUIStatus().gameObject, false);
        UIManager.Instance.GetMainMenu().ShowButtons();
    }
}
