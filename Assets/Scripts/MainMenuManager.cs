using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Build Settings'teki 1. index (Scene1)
    }

    public void QuitGame()
    {
        Debug.Log("Oyun kapatýldý.");
        Application.Quit();
    }
}
