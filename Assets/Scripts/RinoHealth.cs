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

        Debug.Log("Rino öldü! Zaman + " + timeReward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player pozisyonu
            Vector3 playerPos = collision.transform.position;
            Vector3 rinoPos = transform.position;

            // Rino'nun yüzü saða mý sola mý (localScale.x ile güvenli kontrol)
            bool facingRight = transform.localScale.x > 0f;

            bool playerOnRight = playerPos.x > rinoPos.x;

            // Bakýþ yönüne göre hasar ver
            if ((facingRight && !playerOnRight) || (!facingRight && playerOnRight))
            {
                Debug.Log("Player Rino'nun baktýðý yönde. Hasar veriliyor.");
                collision.transform.SetParent(transform);

                if (timerBar != null)
                {
                    float oldTime = timerBar.currentTime;
                    timerBar.currentTime -= timePenalty;
                    Debug.Log("Player'a " + timePenalty + " hasar verildi! Eski can: " + oldTime + " Yeni can: " + timerBar.currentTime);
                }
                else
                {
                    Debug.LogWarning("TimerBar atanmadý!");
                }
            }
            else
            {
                Debug.Log("Player Rino'nun arkasýnda. Hasar verilmedi.");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            Debug.Log("Player platformdan ayrýldý. Parent sýfýrlandý.");
        }
    }
}
