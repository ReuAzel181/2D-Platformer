using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using TMPro;  // Ensure you have this using directive

public class CoinCollected : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI coinText;  
    private int coinCount = 0;
    public class CoinCollectedEvent : UnityEvent<int> { } 
    public CoinCollectedEvent coinCollectedEvent = new CoinCollectedEvent(); // Public reference to the event


    void Start()
    {
        int coinsCollected = PlayerPrefs.GetInt("CoinsCollected", 0);
        coinText.text = coinsCollected.ToString();

        PlayerPrefs.DeleteKey("CoinsCollected");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            coinText.text = "Coins Collected: " + coinCount;
        }
    }

    public void OnGameEnd() // Call this when the game ends (e.g., player dies)
    {
        int previousHighest = PlayerPrefs.GetInt("HighestTotalCoinCount", 0); // Load saved highest score
        if (coinCount > previousHighest)
        {
            PlayerPrefs.SetInt("HighestTotalCoinCount", coinCount); // Update highest score if needed
        }
        PlayerPrefs.SetInt("CoinsCollectedThisGame", 0); // Reset coin count for next game
    }
}

