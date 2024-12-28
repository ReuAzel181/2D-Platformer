using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinCountManager : MonoBehaviour
{
    private static CoinCountManager _instance;
    public static CoinCountManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CoinCountManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return _instance;
        }
    }

    private int coinCount = 0;

    public void AddCoin()
    {
        coinCount++;
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}
