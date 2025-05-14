using UnityEngine;

public class RinoHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public Collider2D rinoCollider;
    public SimpleTimerBar timerBar;
    public float timeReward;
    public float timePenalty = 50f;

    private bool isDead = false;

    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;

        if (rinoCollider == null)
            rinoCollider = GetComponent<Collider2D>();

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        currentHealth -= damageAmount;

        Debug.Log("Rino'ya vuruldu. Kalan can: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        if (rinoCollider != null)
            rinoCollider.enabled = false;

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 3f;
        }

        if (timerBar.currentTime <120)
        {
            timeReward = 60f;
        }
        else
        {
            timeReward = timerBar.maxTime - timerBar.currentTime;
        }

        if (timerBar != null)
            timerBar.currentTime += timeReward;

        Debug.Log("Rino �ld�! Zaman + " + timeReward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player pozisyonu
            Vector3 playerPos = collision.transform.position;
            Vector3 rinoPos = transform.position;

            // Rino'nun y�z� sa�a m� sola m� (localScale.x ile g�venli kontrol)
            bool facingRight = transform.localScale.x > 0f;

            bool playerOnRight = playerPos.x > rinoPos.x;

            // Bak�� y�n�ne g�re hasar ver
            if ((facingRight && !playerOnRight) || (!facingRight && playerOnRight))
            {
                Debug.Log("Player Rino'nun bakt��� y�nde. Hasar veriliyor.");
                collision.transform.SetParent(transform);

                if (timerBar != null)
                {
                    float oldTime = timerBar.currentTime;
                    timerBar.currentTime -= timePenalty;
                    Debug.Log("Player'a " + timePenalty + " hasar verildi! Eski can: " + oldTime + " Yeni can: " + timerBar.currentTime);
                }
                else
                {
                    Debug.LogWarning("TimerBar atanmad�!");
                }
            }
            else
            {
                Debug.Log("Player Rino'nun arkas�nda. Hasar verilmedi.");
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
