using System.Collections;
using UnityEngine;
using TMPro;
public class HighestScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highestScoreText;

    void Start()
    {
        int highestScore = GetHighestCoinCount();
        highestScoreText.text = "Highest Score: " + highestScore;
    }

    private int GetHighestCoinCount()
    {
        int score = 0; // Initialize with a default value

        // Check if CoinCollected script is on the same GameObject
        CoinCollected coinCollected = GetComponent<CoinCollected>();
        if (coinCollected != null)
        {
            int coinCount = int.Parse(coinCollected.coinText.text.Split(':')[1].Trim());

        }
        else
        {
            // Fallback: Check PlayerPrefs if CoinCollected script not found
            if (PlayerPrefs.HasKey("CoinsCollected"))
            {
                score = PlayerPrefs.GetInt("CoinsCollected", 0);
            }
        }

        return score;
    }
}
