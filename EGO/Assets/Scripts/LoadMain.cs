using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain : MonoBehaviour
{
    // Method to load the scene
    public void StartGame()
    {
        SceneManager.LoadScene(0); // Loads the scene at index 0
    }
}
