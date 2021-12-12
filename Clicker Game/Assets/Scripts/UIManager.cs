using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        gameManager.onScoreChanged += UpdateScore;
    }

    public void UpdateScore(int value)
    {
        if (scoreText != null)
            scoreText.text = value.ToString("000000000");
    }

    public void OnPresentClick()
    {
        gameManager.IncreaseScore(gameManager.ClickValue);
    }

    public void OnSave()
    {
        gameManager.Save();
    }
}
