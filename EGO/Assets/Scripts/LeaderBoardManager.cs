using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LeaderboardManager : MonoBehaviour
{
    public class CoinCollectedEvent : UnityEvent<int> { }
    [SerializeField] private CoinCollectedEventHolder coinCollectedEventHolder; // Reference to the CoinCollectedEvent GameObject

    [SerializeField] private TextMeshProUGUI[] scoreTexts; // Text elements to display the top scores

    private TextMeshProUGUI coinText; // Text element to display collected coins
    private ItemCollector itemCollector; // Reference to the ItemCollector script

    private List<ScoreEntry> leaderboard = new List<ScoreEntry>();
    private float startTime; // Time when the game started
    private int coinCount = 0;

    private static LeaderboardManager _instance;

    public static LeaderboardManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LeaderboardManager>();
            }
            return _instance;
        }
    }

    [ContextMenu("Clear Leaderboard")]
    public void ClearLeaderboard()
    {
        PlayerPrefs.DeleteAll(); // Clears all PlayerPrefs data
        leaderboard.Clear(); // Clears the leaderboard list
        DisplayLeaderboard(); // Refreshes the leaderboard display
    }

    private void Start()
    {
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        itemCollector = FindObjectOfType<ItemCollector>();

        // Find and assign the CoinCollectedEventHolder
        coinCollectedEventHolder = GameObject.Find("CoinCollectedEventHolder").GetComponent<CoinCollectedEventHolder>();

        if (coinText == null)
        {
            Debug.LogError("CoinText not found in the scene. Make sure the CoinText GameObject is active.");
            return;
        }

        // Subscribe to the coinCollectedEvent
        coinCollectedEventHolder.coinCollectedEvent.AddListener(OnCoinCollected);

        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        coinText.text = "Score: " + coinCount;
        startTime = Time.time;
        LoadLeaderboard();
        DisplayLeaderboard();
    }

    private void OnCoinCollected(int collectedCoins)
    {
        coinCount += collectedCoins;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        coinText.text = "Coins: " + coinCount;
        AddNewScore(coinCount);
    }

    public void AddNewScore(int score)
    {
        if (leaderboard.Count < 5 || score > leaderboard[leaderboard.Count - 1].score)
        {
            ScoreEntry newEntry = new ScoreEntry(score, GetGameTime());
            leaderboard.Add(newEntry);
            leaderboard.Sort((a, b) => b.score.CompareTo(a.score));

            if (leaderboard.Count > 5)
            {
                leaderboard.RemoveAt(5);
            }

            SaveLeaderboard();
            DisplayLeaderboard();
        }
    }

    private void SaveLeaderboard()
    {
        for (int i = 0; i < leaderboard.Count; i++)
        {
            PlayerPrefs.SetInt("LeaderboardScore" + i, leaderboard[i].score);
            PlayerPrefs.SetFloat("LeaderboardTime" + i, leaderboard[i].time);
        }

        for (int i = leaderboard.Count; i < 5; i++)
        {
            PlayerPrefs.DeleteKey("LeaderboardScore" + i);
            PlayerPrefs.DeleteKey("LeaderboardTime" + i);
        }
    }

    private void LoadLeaderboard()
    {
        leaderboard.Clear();
        for (int i = 0; i < 5; i++)
        {
            string scoreKey = "LeaderboardScore" + i;
            string timeKey = "LeaderboardTime" + i;

            if (PlayerPrefs.HasKey(scoreKey) && PlayerPrefs.HasKey(timeKey))
            {
                int score = PlayerPrefs.GetInt(scoreKey);
                float time = PlayerPrefs.GetFloat(timeKey);
                leaderboard.Add(new ScoreEntry(score, time));
                Debug.Log("Loaded score: " + score + ", time: " + time);
            }
        }
    }


    private void DisplayLeaderboard()
    {
        // Sort the leaderboard before displaying
        leaderboard.Sort((a, b) => b.score.CompareTo(a.score));

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < leaderboard.Count)
            {
                scoreTexts[i].text = (i + 1) + ". " + leaderboard[i].score + " - " + FormatTime(leaderboard[i].time);
            }
            else
            {
                scoreTexts[i].text = (i + 1) + ". ";
            }
        }

        // Debug log to check leaderboard display
        foreach (var entry in leaderboard)
        {
            Debug.Log("Leaderboard entry - Score: " + entry.score + ", Time: " + entry.time);
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return minutes + "m " + seconds + "s";
    }

    private float GetGameTime()
    {
        return Time.time - startTime;
    }
}

[System.Serializable]
public class ScoreEntry
{
    public int score;
    public float time;

    public ScoreEntry(int score, float time)
    {
        this.score = score;
        this.time = time;
    }
}
