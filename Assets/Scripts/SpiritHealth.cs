using UnityEngine;

public class SpiritHealth : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;

    public Collider2D spiritCollider;
    public SimpleTimerBar timerBar;
    public float timePenalty = 30f; // Zaman cezas�
    public float timeReward = 5f;

    private bool isDead = false;

    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;

        if (spiritCollider == null)
            spiritCollider = GetComponent<Collider2D>();

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        currentHealth -= damageAmount;
        Debug.Log("Spirit'e vuruldu. Kalan can: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        if (spiritCollider != null)
            spiritCollider.enabled = false;

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 3f;
        }

        if (timerBar != null)
            timerBar.currentTime += timeReward;

        Debug.Log("Spirit �ld�! Zaman + " + timeReward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Spirit'e de�di. Parent yap�l�yor.");
            collision.transform.SetParent(transform);

            // Do�rudan timerBar kullan
            if (timerBar != null)
            {
                float oldTime = timerBar.currentTime;
                timerBar.currentTime -= timePenalty;
                Debug.Log("Player'a 10 hasar verildi! Eski can: " + oldTime + " Yeni can: " + timerBar.currentTime);
            }
            else
            {
                Debug.LogWarning("TimerBar atanmad�!");
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            Debug.Log("Player platformdan ayr�ld�. Parent s�f�rland�.");
        }
    }
}
