using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    [Header("Game State")]
    public int additionalCoins = 12;
    public int points;
    public int coinsCollected;
    public int chestsOpened;
    public bool isWin;

    [Header("References")]
    public CoinSpawner coinSpawner;

    [Header("UI Elements")]
    public TextMeshProUGUI scorePointsText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI chestText;
    public GameObject winPanel;

    private int winConditionCount;

    private void Start()
    {
        if (coinSpawner == null)
        {
            Debug.LogError("CoinSpawner reference is missing in GameStateManager.");
            return;
        }

        winConditionCount = coinSpawner.spawnCount + additionalCoins;

        UpdateUI();
    }

    public void CollectCoin(int pointsCollected)
    {
        points += pointsCollected;
        coinsCollected++;

        if (coinsCollected >= winConditionCount)
        {
            WinGame();
        }

        UpdateUI();
    }

    public void OpenChest()
    {
        chestsOpened++;
        UpdateUI();
    }

    private void WinGame()
    {
        isWin = true;
        winPanel.SetActive(true);
    }

    private void UpdateUI()
    {
        scorePointsText.text = $"Score: {points}";
        coinsText.text = $"Coins: {coinsCollected}/{winConditionCount}";
        chestText.text = $"Chests: {chestsOpened}";
    }
}
