using UnityEngine;

public class RinoHealth : MonoBehaviour
{
    public int maxHealth = 10;            // Toplam can
    private int currentHealth;

    public Collider2D rinoCollider;       // Rino'nun Collider referans� (Polygon Collider 2D)
    public SimpleTimerBar timerBar;       // Timer referans�
    public float timeReward = 20f;        // �d�l olarak eklenecek zaman

    private bool isDead = false;

    private Rigidbody2D rb;               // Rigidbody2D referans�

    void Start()
    {
        currentHealth = maxHealth;

        if (rinoCollider == null)
            rinoCollider = GetComponent<Collider2D>();

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>(); // Rigidbody yoksa ekle ama Kinematic yap
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // D��ar�dan hasar verme fonksiyonu
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
            rinoCollider.enabled = false; // Collider kapat

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // Art�k d��s�n
            rb.gravityScale = 3f; // D��me h�z�n� art�rabilirsin
        }

        if (timerBar != null)
            timerBar.currentTime += timeReward;

        Debug.Log("Rino �ld�! Zaman + " + timeReward);
    }
}
