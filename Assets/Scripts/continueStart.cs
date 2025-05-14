using UnityEngine;
using UnityEngine.SceneManagement;

public class continueStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame()
    {
        SceneManager.LoadScene(2); // Build Settings'teki 1. index (Scene1)
    }
}
