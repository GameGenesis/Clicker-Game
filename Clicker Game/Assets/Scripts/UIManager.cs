using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject upgradePanel;

    private GameManager gameManager;

    private bool panelEnabled;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        gameManager.onScoreChanged += UpdateScore;
    }

    private void Start()
    {
        upgradePanel.SetActive(false);
    }

    private void OnDestroy()
    {
        gameManager.onScoreChanged -= UpdateScore;
    }

    public void UpdateScore(int value)
    {
        if (scoreText != null)
            scoreText.text = $"{value.ToString()}p";
    }

    public void OnPresentClick()
    {
        gameManager.IncreaseScore(gameManager.ClickValue);
    }

    public void OnUpgrade(int valueIndex)
    {

    }

    public void OnSave()
    {
        gameManager.Save();
    }

    public void OnToggleUpgradePanel()
    {
        panelEnabled = !panelEnabled;
        upgradePanel.SetActive(panelEnabled);
    }
}
