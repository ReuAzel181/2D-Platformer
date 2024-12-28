using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinManager : MonoBehaviour
{

    public Text HighScoreText;

    public static int HighScoreCount;
    private ItemCollector itemCollector;

    void Start()
    {
      
        itemCollector = FindObjectOfType<ItemCollector>(); 

        // Load HighScore from PlayerPrefs (if it exists)
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScoreCount = PlayerPrefs.GetInt("HighScore");
           
        }

        // Update HighScoreText initially (even if no new high score)
        HighScoreText.text = "Highest Score: " + HighScoreCount;
    }

    void Update()
    {
        if (itemCollector.GetCoinCount() > HighScoreCount)
        {
            HighScoreCount = itemCollector.GetCoinCount();
            PlayerPrefs.SetInt("HighScore", HighScoreCount);
           
        }

      
        HighScoreText.text = "Highest Score: " + HighScoreCount;
    }
}
