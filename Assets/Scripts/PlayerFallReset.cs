using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFallReset : MonoBehaviour
{
    public float fallThresholdY = -10f; // Bu Y seviyesinin altýna düþerse tetiklenir.  
    public SimpleTimerBar timerBar; // Timer referansý  

    private bool isResetting = false;

    void Start()
    {
        // TimerBar'ý otomatik bul (Inspector'da atamayý unutursan)  
        if (timerBar == null)
            timerBar = Object.FindFirstObjectByType<SimpleTimerBar>();
    }

    void Update()
    {
        if (!isResetting && transform.position.y < fallThresholdY)
        {
            Debug.Log("Karakter düþtü! Timer sýfýrlanýyor ve sahne yeniden yükleniyor.");

            isResetting = true;

            // Timer sýfýrla (varsa)  
            if (timerBar != null)
            {
                timerBar.currentTime = 0f;
                timerBar.fillImage.fillAmount = 0f;
            }

            // Kýsa gecikme ile sahneyi yeniden yükle  
            Invoke("RestartScene", 0.5f);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
