using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFallReset : MonoBehaviour
{
    public float fallThresholdY = -10f; // Bu Y seviyesinin alt�na d��erse tetiklenir.  
    public SimpleTimerBar timerBar; // Timer referans�  

    private bool isResetting = false;

    void Start()
    {
        // TimerBar'� otomatik bul (Inspector'da atamay� unutursan)  
        if (timerBar == null)
            timerBar = Object.FindFirstObjectByType<SimpleTimerBar>();
    }

    void Update()
    {
        if (!isResetting && transform.position.y < fallThresholdY)
        {
            Debug.Log("Karakter d��t�! Timer s�f�rlan�yor ve sahne yeniden y�kleniyor.");

            isResetting = true;

            // Timer s�f�rla (varsa)  
            if (timerBar != null)
            {
                timerBar.currentTime = 0f;
                timerBar.fillImage.fillAmount = 0f;
            }

            // K�sa gecikme ile sahneyi yeniden y�kle  
            Invoke("RestartScene", 0.5f);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
