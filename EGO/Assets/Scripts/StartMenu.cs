using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ensure the namespace is unique and not conflicting with other scripts
namespace MyGame
{
    public class StartMenu : MonoBehaviour
    {
        // Rename the method to something unique if needed
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
