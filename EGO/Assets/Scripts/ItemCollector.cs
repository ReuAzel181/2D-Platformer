using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; 

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource coinSoundeffect;
    public int coin = 0;

    [SerializeField] private Text coinText; // Reference to Text object for displaying coin count
    public CoinCollectedEvent coinCollectedEvent = new CoinCollectedEvent();
    private void Start()
    {
        coinText.text = "Coin(s): " + coin; // Update the initial coin text
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinSoundeffect.Play();
            coin++;
            coinText.text = "Coin(s): " + coin;
            CollectCoin();
            coinCollectedEvent.Invoke(coin);
        }
    }
    public class CoinCollectedEvent : UnityEvent<int> { }
    private void CollectCoin()
    {
        // Update PlayerPrefs and leaderboard with the current coin count
        PlayerPrefs.SetInt("CoinCount", coin);

        // Check if LeaderboardManager instance exists before calling AddNewScore
        if (LeaderboardManager.instance != null)
        {
            LeaderboardManager.instance.AddNewScore(coin);
        }
        else
        {
            Debug.LogError("LeaderboardManager instance not found!");
        }
    }

    public int GetCoinCount()
    {
        return coin;
    }
}
