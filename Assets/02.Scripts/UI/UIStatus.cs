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
    [SerializeField] private Button backButton;

    void Start()
    {
        backButton.onClick.AddListener(CloseStatus);
    }

    public void SetCharacterStatus(Character player)
    {
        attackText.text = $"{player.TotalAttack}";
        defenseText.text = $"{player.TotalDefense}";
        healthText.text = $"{player.TotalHealth}";
        criticalHitText.text = $"{player.TotalCriticalHit}";
    }

    public void CloseStatus()
    {
        UIManager.Instance.ShowUI(UIManager.Instance.GetUIStatus().gameObject, false);
        UIManager.Instance.GetMainMenu().ShowButtons();
    }
}
