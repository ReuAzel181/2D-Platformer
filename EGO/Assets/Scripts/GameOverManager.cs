using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Text coinText;  // Reference to the UI Text element for coins

    void Start()
    {
        // Retrieve the coin count from PlayerPrefs
        int coinsCollected = PlayerPrefs.GetInt("CoinsCollected", 0);
        coinText.text = "Coins Collected: " + coinsCollected.ToString();

        // Clear the stored coin count
        PlayerPrefs.DeleteKey("CoinsCollected");
    }
}
