using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleTimerBar : MonoBehaviour
{
    public Image fillImage;
    public float maxTime = 120f;
    public float currentTime;

    public GameObject player; // Karakter referansý (2D)
    public float restartDelay = 3f; // Sahneyi yeniden yükleme gecikmesi

    private bool isTimeOver = false;
    private Animator anim;


    void Start()
    {
        currentTime = maxTime;
        fillImage.fillAmount = 1f;

        // Animator referansý alýnýyor
        anim = player.GetComponent<Animator>();
    }

    void Update()
    {
        if (!isTimeOver)
        {
            // Karakter yürürken + 1 saniye azalt
            if (anim != null)
            {
                AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

                // Karakter yürürken 10 saniye azalt
                if (stateInfo.IsName("Walk"))
                {
                    currentTime -= 1f * Time.deltaTime;
                }

                // Karakter koþarken 20 saniye azalt
                if (stateInfo.IsName("Run"))
                {
                    currentTime -= 2f * Time.deltaTime;
                }

                // Karakter zýplarken 10 saniye azalt
                if (stateInfo.IsName("Jump"))
                {
                    currentTime -= 1f * Time.deltaTime;
                }

                // Karakter saldýrýrken 20 saniye azalt
                if (stateInfo.IsName("Left_Punch"))
                {
                    currentTime -= 2f * Time.deltaTime;
                }

                if (stateInfo.IsName("Left_Punch 0"))
                {
                    currentTime -= 2f * Time.deltaTime;
                }

                if (stateInfo.IsName("Left_Punch 1"))
                {
                    currentTime -= 2f * Time.deltaTime;
                }

            }


            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                fillImage.fillAmount = currentTime / maxTime;
            }
            else
            {
                fillImage.fillAmount = 0f;
                TimeIsOver();
            }
        }
    }

    void TimeIsOver()
    {
        isTimeOver = true;

        // 2D Rigidbody ve Collider iþlemleri  
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        CapsuleCollider2D col = player.GetComponent<CapsuleCollider2D>();

        if (col != null)
        {
            col.enabled = false;
        }

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // Fizik motoruna teslim  
            rb.gravityScale = 3f;   // Düþme hýzýný arttýrmak istersen 3 yapabilirsin (default 1)  
        }

        // Gecikmeli sahne yeniden yükleme  
        Invoke("RestartScene", restartDelay);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
