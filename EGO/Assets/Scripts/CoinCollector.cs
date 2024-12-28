using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinCollector : MonoBehaviour
{
    private int coinCount;
    public TextMeshProUGUI coinText;

    public void CollectCoin()
    {
        coinCount++;
        PlayerPrefs.SetInt("CoinCount", coinCount); // Save the coin count
        UpdateCoinText();
        LeaderboardManager.instance.AddNewScore(coinCount); // Pass the coin count to the leaderboard
    }

    private void UpdateCoinText()
    {
        // Update the UI or text element to display the current coin count
        // For example, if you have a TextMeshProUGUI element named coinText:
        coinText.text = "Coins: " + coinCount;
    }
}
