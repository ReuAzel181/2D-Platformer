using UnityEngine;
using UnityEngine.Events;

public class CoinCollectedEventHolder : MonoBehaviour
{
    public UnityEvent<int> coinCollectedEvent = new UnityEvent<int>();

    private void Awake()
    {
        // Ensure that this GameObject persists between scenes
        DontDestroyOnLoad(gameObject);
    }
}
